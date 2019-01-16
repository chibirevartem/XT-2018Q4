using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.Task08._1.DATE_EXISTANCE
{
    class Program
    {
        public const string datePattern = @"\b(0[1-9]|1[0-9]|2[0-9]|3[1])-(0[1-9]|1[12])-[0-9]{4}\b";
        
        static void Main(string[] args)
        {
            Regex regex = new Regex(datePattern);
            while (true)
            {
                Console.WriteLine($"Write a text consisting a date in dd-mm-yyyy format:");
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    foreach (Match match in regex.Matches(input))
                    {
                        Console.WriteLine($"Found {match.Value} at position {match.Index}");
                    }
                }
                else { Console.WriteLine("No matches found."); }
            }
            
        }
    }
}
