using System;

namespace HumanRightsIndicator
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro();
            char wantToInquire = IsYesOrNo("Are you interested in inquiring any country's Human Rights Score in this list (Y/N): ");
            while (wantToInquire == 'Y')
            {
                Console.Clear();
                Inquire();
                Console.ReadLine();
                Console.Clear();
                wantToInquire = IsYesOrNo("Do you want to continue to inquire: ");
            }
            Console.Clear();
            Console.WriteLine("Thank you for visiting!");
            
            Console.ReadLine();
        }

        static void DisplayCountries()
        {
            Console.WriteLine("---------------SELECTED COUNTRIES/REGIONS HUMAN RIGHTS SCORE (1988 - 2017)---------------");            
            for(int i=1; i<Data.Countries.Length; i++)
            {
                Console.WriteLine($"                                         {Data.Countries[i]}");
            }
            Console.WriteLine("---------------------------------------END OF LIST---------------------------------------");           
        }
        
        static void Inquire()
        {
            DisplayCountries();
            Console.WriteLine();

            CountryModel country = new CountryModel();
            country.CountryName = CountryInInquiry("Which country in the list do you want to inquire: ");
            country.Year = YearInInQuiry("Which year of this country's Human Rights Score do you want to see: ");
            double humanRightsIndex = country[country.Year];
            Console.WriteLine();

            Console.WriteLine("==================== INQUIRY RESULT ====================");            
            Console.WriteLine($"The Human Rights Score for {country.CountryName} in {country.Year} is {humanRightsIndex}.");
            Console.WriteLine($"The average Human Rights Score among the countries in this list in {country.Year} is {Data.AvgIndexByYear(country.Year):f2}.");
            Console.WriteLine($"{country.CountryName}'s Human Rights Score is {country.HumanRightsLevelGroup(humanRightsIndex,country.Year)}.");
            Console.WriteLine("===================== END OF RESULT ====================");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string CountryInInquiry(string message)
        {
            Console.Write(message);
            string output = Console.ReadLine().ToUpper();
            while (Array.IndexOf(Data.Countries,output) == -1)
            {
                Console.Write("Please only enter a country in the list: ");
                output = Console.ReadLine().ToUpper();
            }

            return output;
        }

        static int YearInInQuiry(string message)
        {
            Console.Write(message);
            string userAnswer = Console.ReadLine();
            bool isValidInt = int.TryParse(userAnswer, out int output);

            while (isValidInt == false || Array.IndexOf(Data.Years(),output) == -1)
            {
                Console.Write("Please enter a four-digit year within the year range indicated in the display: ");
                userAnswer = Console.ReadLine();
                isValidInt = int.TryParse(userAnswer, out output);
            }

            return output;
        }

        static char IsYesOrNo(string message)
        {
            Console.Write(message);
            string userAnswer = Console.ReadLine().ToUpper();
            bool isValidAnswer = char.TryParse(userAnswer, out char output);
            while (isValidAnswer == false || (output != 'Y' && output != 'N'))
            {
                Console.Write("Please type \"Y\" or \"N\" (one-letter only): ");
                userAnswer = Console.ReadLine().ToUpper();
                isValidAnswer = char.TryParse(userAnswer, out output);
            }

            return output;
        }

        static void Intro()
        {
            Console.WriteLine("======================= INTRODUCTION ======================");
            Console.WriteLine("     This program uses Dr. Keith Schnakenberg and \n     Dr. Christopher Fariss' Dynamic Patterns of Human");
            Console.WriteLine("     Rights Practice to trace countrie's human rights \n     record over time with consistency in measuring method.");
            Console.WriteLine("     The dataset is derived from Our World in Data website ");
            Console.WriteLine(@"     (https://ourworldindata.org/human-rights) on Saturday,");
            Console.WriteLine("     July 11, 2020. Hope you will enjoy.");
            Console.WriteLine("                                                 -Zhidong");
            Console.WriteLine("=================== END OF INTRODUCTION ===================");
            Console.WriteLine();
            Console.WriteLine("(Click enter to continue program)");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
