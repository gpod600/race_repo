using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Race
{
    public class FileWriter
    {
        public Boolean Write(String fileName, DataTable table, Boolean overwrite = true)
        {
            if ( File.Exists(fileName) )
            {
                if (overwrite == false)
                    return false;
                File.Delete(fileName);
            }

            IList<String> ColumnNames = new List<String>();
            StreamWriter Writer = new StreamWriter(fileName);
            String Line;
            StringBuilder Text = new StringBuilder();
            foreach (DataColumn Column in table.Columns)
            {
                Text.Append(Column.ColumnName + ",");
                ColumnNames.Add(Column.ColumnName);
            }
            Line = Text.ToString();
            Line = Line.Substring(0, Line.Length-1);
            Writer.WriteLine(Line);

            foreach (DataRow Row in table.Rows)
            {
                Text.Clear();
                foreach (String Column in ColumnNames)
                    Text.Append(Row[Column] + ",");
                Line = Text.ToString();
                Line = Line.Substring(0, Line.Length - 1);
                Writer.WriteLine(Line);
            }

            Writer.Close();


            return true;
        }
    }
}
