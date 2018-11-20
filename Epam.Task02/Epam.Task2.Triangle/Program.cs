using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Triangle
{
    class Program
    {
        static void Triangle(int length)
        {
            if (length>0)
            {
                if (length < 100)
                {
                    int i = 1;
                    while (i <= length)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine(" ");
                        i++;
                    }
                }

                else { Console.WriteLine("Too much.Try again"); }
                
            }
            else { Console.WriteLine("The length must be positive and beetween 0-100"); }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nThis is a Triangle-creator. Type in length and press ENTER:");
                int input;

                bool success = Int32.TryParse(Console.ReadLine(), out input);

                if (success) { Triangle(input); }
                else { Console.WriteLine("Incorrect input data"); }
            }
            
        }
    }
}
