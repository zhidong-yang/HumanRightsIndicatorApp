using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HumanRightsIndicator
{
    public static class Data
    {        
        // First make sure that other than the first cell in first line, all other data cells are not null; otherwise data may not match country/year
        static List<string> lines = File.ReadAllLines("HumanRightsDataCSV.csv").ToList();
        
        public static string[] Countries = lines[0].ToUpper().Split(','); // remember the first item is blank cell

        public static int[] Years()
        {
            int[] output = new int[lines.Count - 1];
            for (int i = 1; i<lines.Count; i++) // starting the loop from the second line
            {
                string[] lineEntries = lines[i].Split(',');

                output[i - 1] = Convert.ToInt32(lineEntries[0]);
            }

            return output;
        }
        
        public static double[,] HumanRightsIndices()
        {
            int[] years = Years();
            double[,] output = new double[Countries.Length - 1, years.Length];
            for (int i = 1; i < Countries.Length; i++) // Starting from the second column of the first line in csv file
            {
                for (int j = 1; j < lines.Count; j++)
                {
                    string[] lineEntries = lines[j].Split(',');

                    output[i - 1, j - 1] = Convert.ToDouble(lineEntries[i]);
                }
            }
            return output;
        }

        public static double AvgIndexByYear(int year)
        {
            int yearIndex = Array.IndexOf(Years(), year);
 
            double sum = 0.00;
            for (int i = 1; i < Countries.Length; i++)
            {
                sum += HumanRightsIndices()[i-1, yearIndex];
            }
            double output = sum / (Countries.Length - 1);

            return output;

        }
    }
}
