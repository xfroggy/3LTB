using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LTB.Models
{
    public class BulkSequenceData
    {
        static List<Dictionary<string, string>> AllSequences = new List<Dictionary<string, string>>();
        static bool IsDataLoaded = false;


        public static List<Dictionary<string, string>> FindAll()
        {
            LoadData();
            List<Dictionary<string, string>> Sequences = new List<Dictionary<string, string>>();
            foreach (Dictionary<string, string> sequence in AllSequences)
            {
                Sequences.Add(sequence);
            }
            return Sequences;
        }

        /*
         * Returns a list of all values contained in a given column,
         * without duplicates. 
         */
        public static List<string> FindAll(string column)
        {
            LoadData();

            // string[] jobs = new string[AllJobs.Count;
            List<string> values = new List<string>();

            foreach (Dictionary<string, string> sequence in AllSequences)
            {
                string aValue = sequence[column];

                if (!values.Contains(aValue))
                {
                    values.Add(aValue);
                }
            }
            return values;
        }

        //public static List<Dictionary<string, string>> FindByColumnAndValue(string column, string value)
        //{
        //    // load data, if not already loaded
        //    LoadData();

        //    List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

        //    foreach (Dictionary<string, string> row in AllJobs)
        //    {
        //        string aValue = row[column].ToLower();

        //        if (aValue.Contains(value.ToLower()))
        //        {
        //            jobs.Add(row);
        //        }
        //    }


        //    return jobs;
        //}



        //public static List<Dictionary<string, string>> FindByValue(string value)
        //{
        //    // load dada, if not already loaded
        //    LoadData();

        //    List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

        //    foreach (Dictionary<string, string> row in AllJobs)
        //    {
        //        foreach (KeyValuePair<string, string> column in row)
        //        {
        //            if (column.Value.ToLower().Contains(value.ToLower()) && !jobs.Contains(row))
        //            {
        //                jobs.Add(row);
        //            }
        //        }
        //    }
        //    return jobs;

        //}


        /*
         * Load and parse data from job_data.csv
         */
        private static void LoadData()
        {

            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText("C:/Users/xfrog/lc101/3LTB - dev/3LTB/3LTB/SeedData/MIA-CSV.csv"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArrray = CSVRowToStringArray(line);
                    if (rowArrray.Length > 0)
                    {
                        rows.Add(rowArrray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            // Parse each row array into a more friendly Dictionary
            foreach (string[] row in rows)
            {
                Dictionary<string, string> rowDict = new Dictionary<string, string>();

                for (int i = 0; i < headers.Length; i++)
                {
                    rowDict.Add(headers[i], row[i]);
                }
                AllSequences.Add(rowDict);
            }

            IsDataLoaded = true;
        }

        /*
         * Parse a single line of a CSV file into a string array
         */
        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }


    }
}
