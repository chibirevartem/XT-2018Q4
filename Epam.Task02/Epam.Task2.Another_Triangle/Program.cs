using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Another_Triangle
{
    class Program
    {

        public static void Another_triangle(int n)
        {
            if (n > 0 & n < 40)
            {
                int length = 2 * n - 1;
                int middle = (length - 1) / 2;


                for (int i = 0; i < n; i++)
                {
                    for (int pointer = 0; pointer < length; pointer++)
                    {
                        if((pointer<(middle-i))||(pointer > (middle + i)))
                        {
                            Console.Write(" ");
                        }

                        else { Console.Write("*"); }
                    }

                    Console.WriteLine(" ");
                }
            }

            else { Console.WriteLine("The value must be beetween 0 and 40"); }
            
        }
        static void Main(string[] args)
        {
            

            while (true)
            {
                Console.WriteLine("\nThis is an AnotherTriangle-creator. Type in length and press ENTER:");
                int input;

                bool success = Int32.TryParse(Console.ReadLine(), out input);

                if (success) { Another_triangle(input); }
                else { Console.WriteLine("Incorrect input data"); }
            }
        }
    }
}
