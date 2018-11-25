 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.CHAR_DOUBLER
{
    class Program
    {
        public static void Char_Doubler(string input, string comparison)
        {
            Console.Write("Char-doubler output:");
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{input[i]}");

                
                    for (int j = 0; j < comparison.Length; j++)
                    {
                        if (char.IsLetter(input[i]) & (char.ToLower(input[i]) == char.ToLower(comparison[j])))
                        {
                            Console.Write($"{comparison[j]}");
                        }

                        else if(input[i] == comparison[j])
                        {
                            Console.Write($"{comparison[j]}");
                        }
                    }

            }
            Console.WriteLine("");
        }                 
         
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write($"\nPlease, write the first string:");
                string input = Console.ReadLine();
                Console.Write($"Please, write the second string:");
                string comparison = Console.ReadLine();
                Char_Doubler(input, comparison);
            }
            
        }
    }
}
