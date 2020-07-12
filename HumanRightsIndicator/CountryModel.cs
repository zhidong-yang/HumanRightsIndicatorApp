using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HumanRightsIndicator
{
    public class CountryModel
    {
        public string CountryName { get; set; }
        public int Year { get; set;}
        public double this[int year] 
        {
            get
            {
                int yearIndex = Array.IndexOf(Data.Years(), Year);

                return HumanRightsIndex()[yearIndex];
            }
        }
        public double[] HumanRightsIndex() 
        {
            int countryIndex = Array.IndexOf(Data.Countries, CountryName);

            int yearCount = Data.Years().Length;
            double[] output = new double[yearCount];

            double[,] fullIndices = Data.HumanRightsIndices();
            for (int i = 0; i < yearCount; i++)
            {
                output[i] = fullIndices[countryIndex - 1, i];
            }

            return output;   
        }

        public string HumanRightsLevelGroup(double index, int year)
        {
            double avgLevelofYear = Data.AvgIndexByYear(year);
            string output = "";

            if (index < avgLevelofYear)
            {
                output = "below average";
            }
            else if (index > avgLevelofYear)
            {
                output = "above average";
            }
            else
            {
                output = "average";
            }

            return output;
        }
    }
}
