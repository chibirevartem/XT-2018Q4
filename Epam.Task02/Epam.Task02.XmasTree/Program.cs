using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.XmasTree
{
    class Program
    {
        public static void Xmas_Tree(int n)
        {
            if (n > 0 & n <= 20)
            {
                
                int length = 2 * n - 1;
                int middle = (length) / 2;

                for (int j = 0; j <= n; j++)
                {
                    for (int i = 0; i < j; i++) // доделать
                    {

                        for (int pointer = 0; pointer < length; pointer++)
                        {
                            if ((pointer < (middle - i)) || (pointer > (middle + i)))
                            {
                                Console.Write(" ");
                            }

                            else { Console.Write("*"); }
                        }

                        Console.WriteLine(" ");
                    }
                }

                
            }

            else { Console.WriteLine("The value must be beetween 0 and 20"); }

        }

 

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nThis is XmasTree-creator.\nType in a quantity of triangles and press ENTER:");
                int input;

                bool success = Int32.TryParse(Console.ReadLine(), out input);

                if (success) { Xmas_Tree(input); }
                else { Console.WriteLine("Incorrect input data"); }
            }
        }
    }
}
