using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Race
{
    public class FileReader
    {
        public Boolean Read(String fileName, IList<String> columns, IDictionary<int, IList<String>> rows)
        {
            if ( File.Exists(fileName) == false)
            {
                return false;
            }

            IList<String> ColumnNames = new List<String>();
            StreamReader Reader = new StreamReader(fileName);

            String Line = Reader.ReadLine();
            columns = Line.Split(',').ToList();

            IDictionary<String, String> Rows = new Dictionary<String, String>();

            int RowIndex=0;        
            while(Reader.EndOfStream == false)
            {
                Line = Reader.ReadLine();
                rows.Add(RowIndex++, Line.Split(',').ToList());
            }

            Reader.Close();

            return true;
        }
    }
}
