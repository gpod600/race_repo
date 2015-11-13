using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using Race.Data;

namespace Race
{
    internal class DataAccess
    {
        private IDictionary<String, int> mRaceTypes = null;
        private IDictionary<String, String> mClubs = null;
        private IDictionary<String, String> mCategories = null;
        private String mConnectionString = "server=localhost;uid=Ger;pwd=Imbrc90*;database=race";
        MySqlConnection mDataBaseConnection;

        internal Boolean Open()
        {
            try
            {
                mDataBaseConnection = new MySqlConnection(mConnectionString);
                mDataBaseConnection.Open();
                return true;
            }
            catch
            {
                return false;
           }
        }

        internal void Close()
        {
            mDataBaseConnection.Close();
        }

        internal object GetRiderDataSet()
        {
            if (mDataBaseConnection != null)
            {
                
                //mClubs = GetClubs();
                //mCategories = GetCategories();

                //GetRiderDataSet(mDataBaseConnection);
                //SaveRiders();
                //LoadRiders();
                return GetRiderDataSet(mDataBaseConnection);
            }
            else
            { 
                return null;
            }
        }

        private void SaveRiders()
        {
            DataTable DataTable = GetRaceDataTable(mDataBaseConnection, "*", "rider");
            FileWriter FileWriter = new Race.FileWriter();
            FileWriter.Write(@"c:\temp\riders.csv", DataTable, true);
        }

        private void LoadRiders()
        {
            FileReader Reader = new FileReader();
            IList<String> Headers = new List<string>();
            IDictionary<int, IList<string>> Rows = new Dictionary<int, IList<string>>();
            if (Reader.Read(@"C:\temp\riders.modified.csv", Headers, Rows))
            {
                foreach (KeyValuePair<int, IList<String>> KV in Rows)
                {
                    String CatName = mCategories.First(x => x.Value == KV.Value[2]).Key;
                    String ClubName = mClubs.First(x => x.Value == KV.Value[3]).Key;
                    String Number = KV.Value[4];
                    String T = KV.Value[1] + ClubName + CatName;
                    if (mRiders.Contains(T) == false)
                        AddRider(KV.Value[1], ClubName, CatName, Number);
                }
            }
        }


        public DataSet GetRacesDataSet()
        {
            if (mDataBaseConnection != null)
            {
                string QueryString = "select races.race, races.laps, racetype.type " +
                                     "from race.races " +
                                     "inner join racetype on races.type = racetype.idracetype " +
                                     "order by races.laps";
                MySqlCommand SqlCommand = new MySqlCommand(QueryString, mDataBaseConnection);
                MySqlDataAdapter Adapter = new MySqlDataAdapter(SqlCommand);
                DataSet Table = new DataSet();
                Adapter.Fill(Table, "LoadDataBinding");
                Table.Tables[0].Columns[0].ColumnName = "Race";
                Table.Tables[0].Columns[1].ColumnName = "Laps";
                Table.Tables[0].Columns[2].ColumnName = "Type";

                return Table;
            }
            return null;
        }

        DataSet GetRiderDataSet(MySqlConnection DataBaseConnection)
        {
            string QueryString = "select rider.name, rider.number, club.name, category.cat " +
                                 "from race.rider " +
                                 "inner join club on rider.club = club.idclub " +
                                 "inner join category on rider.cat = category.idcategory " +
                                 "order by rider.number";
            MySqlCommand SqlCommand = new MySqlCommand(QueryString, DataBaseConnection);
            MySqlDataAdapter Adapter = new MySqlDataAdapter(SqlCommand);
            DataSet Table = new DataSet();
            Adapter.Fill(Table, "LoadDataBinding");
            Table.Tables[0].Columns[0].ColumnName = "Name";
            Table.Tables[0].Columns[1].ColumnName = "Number";
            Table.Tables[0].Columns[2].ColumnName = "Club";
            Table.Tables[0].Columns[3].ColumnName = "Category";

            foreach (DataRow Row in Table.Tables[0].Rows)
                mRiders.Add(Row[0].ToString() + Row[1].ToString() + Row[2].ToString());

            return Table;
        }

        internal object GetRaceDataSet(String selection, String table)
        {
            if (mDataBaseConnection != null)
                return GetRaceDataSet(mDataBaseConnection, selection, table);
            else
                return null;
        }

        internal DataSet GetRaceDataSet(MySqlConnection DataBaseConnection, String selection, String table)
        {
            string QueryString = String.Format("SELECT {0} FROM {1}", selection, table);
            MySqlCommand SqlCommand = new MySqlCommand(QueryString, DataBaseConnection);
            MySqlDataAdapter Adapter = new MySqlDataAdapter(SqlCommand);
            DataSet Table = new DataSet();
            Adapter.Fill(Table, "LoadDataBinding");
            return Table;
        }

        internal object GetRaceDataTable(String selection, String table)
        {
            if (mDataBaseConnection != null)
                return GetRaceDataTable(mDataBaseConnection, selection, table);
            else
                return null;
        }

        internal DataTable GetRaceDataTable(MySqlConnection DataBaseConnection, String selection, String table)
        {
            string QueryString = String.Format("SELECT {0} FROM {1}", selection, table);
            MySqlCommand SqlCommand = new MySqlCommand(QueryString, DataBaseConnection);
            MySqlDataAdapter Adapter = new MySqlDataAdapter(SqlCommand);
            DataSet Table = new DataSet();
            Adapter.Fill(Table, table);
            return Table.Tables[table];
        }

        internal void AddCategory(String category)
        {
            if (mDataBaseConnection != null)
            {
                string QueryString = String.Format(@"INSERT into category(cat) Value('{0}')", category);
                MySqlCommand SqlCommand = new MySqlCommand(QueryString, mDataBaseConnection);
                SqlCommand.ExecuteNonQuery();
            }
        }

        internal void AddClub(String name)
        {
            if (mDataBaseConnection != null)
            {
                string QueryString = String.Format(@"INSERT into club(name) Value('{0}')", name);
                MySqlCommand SqlCommand = new MySqlCommand(QueryString, mDataBaseConnection);
                SqlCommand.ExecuteNonQuery();
            }
        }

        private string GetId(string key, IDictionary<string, string> dictionary)
        {
            String Id = String.Empty;
            if (String.IsNullOrEmpty(key) == false)
                Id = dictionary[key];
            return Id;
        }

        IList<String> mRiders = new List<String>();

        internal void AddRider(String name, String club, String category, String number)
        {
            MySqlConnection DataBaseConnection = new MySqlConnection(mConnectionString);

            if (mClubs == null)
                mClubs = GetClubs();

            if (mCategories == null)
                mCategories = GetCategories();

            String ClubId = GetId(club, mClubs);
            String CategoryId = GetId(category, mCategories);

            string QueryString = String.Format(@"INSERT into rider(name, club, cat, number) Value('{0}', '{1}', '{2}', '{3}')", name, ClubId, CategoryId, number);
            MySqlCommand SqlCommand = new MySqlCommand(QueryString, mDataBaseConnection);
            SqlCommand.ExecuteNonQuery();
        }

        internal void AddRaceEntry(uint raceId, uint lap, String timestamp, uint riderNumber)
        {
            MySqlConnection DataBaseConnection = new MySqlConnection(mConnectionString);
            string QueryString = String.Format(@"INSERT into racelaps(raceId, lap, timestamp, rider) Value('{0}', '{1}', '{2}', {3})", roundId, lap, timestamp, riderNumber);
            MySqlCommand SqlCommand = new MySqlCommand(QueryString, mDataBaseConnection);
            SqlCommand.ExecuteNonQuery();
        }

        internal void AddRaceRound(String name, String laps, String type)
        {
            MySqlConnection DataBaseConnection = new MySqlConnection(mConnectionString);
            if (mRaceTypes== null)
                mRaceTypes = GetRaceTypes();

            string QueryString = String.Format(@"INSERT into races(race, laps, type) Value('{0}', '{1}', '{2}')", name, laps, mRaceTypes[type]);
            MySqlCommand SqlCommand = new MySqlCommand(QueryString, mDataBaseConnection);
            SqlCommand.ExecuteNonQuery();
        }

        internal IDictionary<String, String> GetRaceRounds()
        {
            if (mDataBaseConnection != null)
            {
                DataTable DataTable = GetRaceDataTable(mDataBaseConnection, "*", "round");

                IDictionary<String, String> RaceTypes = new Dictionary<String, String>();
                foreach (DataRow Row in DataTable.Rows)
                    RaceTypes.Add(Row["idround"].ToString(), Row["datetime"].ToString());

                FileWriter FileWriter = new Race.FileWriter();
                FileWriter.Write(@"c:\temp\racetypes.csv", DataTable, true);

                DataTable.Columns[0].ColumnName = "Type";
                DataTable.Columns[1].ColumnName = "Id";
                return RaceTypes;
            }
            return null;
        }
        internal IDictionary<String, int> GetRaceTypes()
        {
            if (mDataBaseConnection != null)
            {
                DataTable DataTable = GetRaceDataTable(mDataBaseConnection, "*", "racetype");

                IDictionary<String, int> RaceTypes = new Dictionary<String, int>();
                foreach (DataRow Row in DataTable.Rows)
                    RaceTypes.Add(Row["type"].ToString(), Int32.Parse(Row["idracetype"].ToString()));

                FileWriter FileWriter = new Race.FileWriter();
                FileWriter.Write(@"c:\temp\racetypes.csv", DataTable, true);

                DataTable.Columns[0].ColumnName = "Type";
                DataTable.Columns[1].ColumnName = "Id";
                return RaceTypes;
            }
            return null;
        }

        internal IDictionary<String, String> GetClubs()
        {
            if (mDataBaseConnection != null)
            {
                DataTable DataTable = GetRaceDataTable(mDataBaseConnection, "*", "club");

                IDictionary<String, String> Clubs = new Dictionary<String, String>();
                foreach (DataRow Row in DataTable.Rows)
                    Clubs.Add(Row["name"].ToString(), Row["idclub"].ToString());

                FileWriter FileWriter = new Race.FileWriter();
                FileWriter.Write(@"c:\temp\clubs.csv", DataTable, true);

                DataTable.Columns[0].ColumnName = "Name";
                return Clubs;
            }
            return null;
        }

        internal IDictionary<String, String> GetCategories()
        {
            if (mDataBaseConnection != null)
            {
                DataTable DataTable = GetRaceDataTable(mDataBaseConnection, "*", "category");
                IDictionary<String, String> Categories = new Dictionary<String, String>();

                foreach (DataRow Row in DataTable.Rows)
                    Categories.Add(Row["cat"].ToString(), Row["idcategory"].ToString());

                FileWriter FileWriter = new Race.FileWriter();
                FileWriter.Write(@"c:\temp\categories.csv", DataTable, true);

                FileReader Reader = new FileReader();
                IList<String> Headers = new List<string>();
                IDictionary<int, IList<string>> Rows = new Dictionary<int, IList<string>>();
                if (Reader.Read(@"C:\temp\categories.updated.csv", Headers, Rows))
                {
                    foreach (KeyValuePair<int, IList<String>> KV in Rows)
                    {
                        if (Categories.Keys.Contains(KV.Value[1]) == false)
                        {
                            AddCategory(KV.Value[1]);
                        }
                    }
                }
                return Categories;
            }
            return null;
        }

        internal IEnumerable<RaceInfo> GetRaces()
        {
            if (mDataBaseConnection != null)
            {
                DataTable DataTable = GetRaceDataTable(mDataBaseConnection, "*", "races");
                IList<RaceInfo> Races = new List<RaceInfo>();
                mRaceIds.Clear();
                foreach (DataRow Row in DataTable.Rows)
                {
                    Races.Add(new RaceInfo() { Laps = Row["laps"].ToString(), Type = Row["type"].ToString(), Name = Row["race"].ToString() });
                    mRaceIds.Add(Row["race"].ToString(), UInt32.Parse(Row["idrace"].ToString()));
                }

                FileWriter FileWriter = new Race.FileWriter();
                FileWriter.Write(@"c:\temp\race.csv", DataTable, true);
                return Races;

                        /*
                FileReader Reader = new FileReader();
                IList<String> Headers = new List<string>();
                IDictionary<int, IList<string>> Rows = new Dictionary<int, IList<string>>();
                if (Reader.Read(@"C:\temp\race.updated.csv", Headers, Rows))
                {
                    foreach (KeyValuePair<int, IList<String>> KV in Rows)
                    {
                        if (Categories.Keys.Contains(KV.Value[1]) == false)
                        {
                            AddCategory(KV.Value[1]);
                        }
                    }
                }*/

                
            }
            return null;
        }

        internal IDictionary<string, string> GetRiders()
        {
            if (mDataBaseConnection != null)
            {
                DataTable DataTable = GetRaceDataTable(mDataBaseConnection, "*", "rider");
                IDictionary<String, String> Riders = new Dictionary<String, String>();

                foreach (DataRow Row in DataTable.Rows)
                    Riders.Add(Row["name"].ToString() + Row["club"].ToString() + Row["cat"].ToString(), Row["number"].ToString());

                return Riders;
            }
            return null;
        }

        IDictionary<String, uint> mRaceIds = new Dictionary<String, uint>();
        internal uint GetRaceId(String raceName)
        {
            if (mRaceIds.Any() == false)
                GetRaces();

            if ( mRaceIds.ContainsKey(raceName))
                return mRaceIds[raceName];
            return 0;
        }
    }
}
