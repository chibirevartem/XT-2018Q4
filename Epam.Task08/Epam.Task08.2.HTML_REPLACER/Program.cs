using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.Task08._2.HTML_REPLACER
{
    class Program
    {
        public const string HTMLPattern = @"(?:<[^>]+>)";
        public const string tagReplacer = "_";
        public const string example = "<b>This</b> is <i>text</i> with <font color=\"red\">HTML</font> tags.";

        static void Main(string[] args)
        {
            Regex regex = new Regex(HTMLPattern);

            Console.WriteLine($"This is a demo of HTML-tag replacing.");
            Console.WriteLine($"Before replacing: {Program.example}");
            Console.WriteLine($"After replacing: {regex.Replace(example, tagReplacer)}");

            while (true)
            {
                Console.WriteLine($"Write a text with HTML-tags:");
                string input = Console.ReadLine();
                bool success = regex.IsMatch(input);

                if (success)
                {
                    string afterReplace = regex.Replace(input, tagReplacer);
                    Console.WriteLine($"After replacing:{afterReplace}");
                }
                else { Console.WriteLine("Pattern error"); }
            }
        }

    }
}
