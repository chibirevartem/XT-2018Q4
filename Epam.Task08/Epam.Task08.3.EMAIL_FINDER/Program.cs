using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.Task08._3.EMAIL_FINDER
{
    class Program
    {
        public const string emailPattern = @"(?:\b[A-Za-z0-9]+[_\-.]*[A-Za-z0-9]+@(?:[A-Za-z0-9\-\.])*\.[A-Za-z]{2,6})";

        static void Main(string[] args)
        {
            Regex regex = new Regex(emailPattern);
            while (true)
            {
                Console.WriteLine($"Write a text, consisting email(s):");
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
