using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.Task08._4.NUMBER_VALIDATOR
{
    class Program
    {
        public const string ScientificPattern = @"(^[+-]?[0-9]+(?:\.[0-9]+)*(?:E|e)[+-]?[0-9]+$)";
        public const string NormalPattern = @"(^[+-]?[0-9]+(?:\.[0-9]+)?$)";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Write a number to check the kind of notation:");
                string input = Console.ReadLine();
                bool IsScientific = Regex.IsMatch(input, ScientificPattern);
                bool IsNormal = Regex.IsMatch(input, NormalPattern);
                if (IsScientific)
                {
                    Console.WriteLine("This is a scientific notation");
                }
                else if (IsNormal)
                {
                    Console.WriteLine("This is a normal notation");
                }
                else { Console.WriteLine("This is not a number"); }
            }

        }
    }
}
