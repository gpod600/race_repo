using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Race.Data;


namespace Race
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private IDictionary<String, String> mClubs = new Dictionary<String, String>();
        private IDictionary<String, String> mCategories = new Dictionary<String, String>();
        private IDictionary<String, String> mRiders = new Dictionary<String, String>();
        private IDictionary<String, int> mRaceTypes;
        private IDictionary<String, String> mRounds;
        DataAccess mAccess;
        RaceInfo mRaceInfo;

        public MainWindow(RaceInfo raceInfo)
        {
            mRaceInfo = raceInfo;
            Title = raceInfo.Name;
            mAccess = new DataAccess();
            mAccess.Open();
            InitializeComponent();
            FillDataGrid();
            Closed += OnClosed;
        }
        void OnClosed(object sender, EventArgs e)
        {
            if ( mAccess != null )
                mAccess.Close();
        }
        private void FillDataGrid()
        {
            mRounds = mAccess.GetRaceRounds();
            mRaceTypes = mAccess.GetRaceTypes();
            mClubs = mAccess.GetClubs();
            mCategories = mAccess.GetCategories();

            mRiders = mAccess.GetRiders();

            

            mRidersUserControl.AllRiders.DataContext = mAccess.GetRiderDataSet();

            mRaceUserControl.DataAccess = mAccess;
            mRaceUserControl.RaceInfo = mRaceInfo;

            mRaceUserControl.Riders.DataContext = mAccess.GetRaceDataSet("name", "rider");

            mClubsUserControl.Clubs.DataContext = mAccess.GetRaceDataSet("name", "club");

            mClubsUserControl.AddNewClub += AddNewClubHandler;

            mRidersUserControl.AddNewRider += AddNewRiderHandler;

        }

        void AddNewRiderHandler(object sender, RoutedEventArgs e)
        {
            NewRiderWindow NewRiderWindow = new NewRiderWindow();

            NewRiderWindow.DataContext = new RiderDataModel(mAccess.GetClubs().Keys.ToArray(), mAccess.GetCategories().Keys.ToArray());

            NewRiderWindow.AddNewRider += mAccess.AddRider;
            NewRiderWindow.ExistingRiders = mRiders;
            NewRiderWindow.ShowDialog();

            mRidersUserControl.AllRiders.DataContext = mAccess.GetRiderDataSet();
        }

        void AddNewClubHandler(object sender, RoutedEventArgs e)
        {
            NewClubWindow NewClubWindow = new NewClubWindow();

            NewClubWindow.AddClubHandler += mAccess.AddClub;
            NewClubWindow.ExistingClubs = mClubs.Keys.ToArray();
            NewClubWindow.ShowDialog();
            mClubsUserControl.Clubs.DataContext = mAccess.GetRaceDataSet("name", "club");

        }

        private void mClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

