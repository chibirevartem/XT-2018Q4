using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.Task08._5.TIME_COUNTER
{
    class Program
    {
        private const string TimePattern = @"\b(0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Write a text to check how many times matches a time");
                string input = Console.ReadLine();
                bool success = Regex.IsMatch(input, TimePattern);
               
                if (success)
                {
                    int matchesCount = Regex.Matches(input, TimePattern).Count;
                    if (matchesCount == 1)
                    {
                        Console.WriteLine($"The time matches one time");
                    }
                    else
                    {
                        Console.WriteLine($"The time matches {matchesCount} times");
                    }
                    
                }

                else { Console.WriteLine("There are no matches"); }
            }
        }
    }
}
