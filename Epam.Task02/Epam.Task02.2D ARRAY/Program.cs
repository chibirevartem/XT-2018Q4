using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._2D_ARRAY
{
    class Program
    {
        public static void TwoDimension_Array()
        {
            Random rand = new Random();
            int i = rand.Next(1, 10);
            int j = rand.Next(1, 10);
            int[,] arr = new int[i, j];
            int even_sum = 0;

            Console.WriteLine("Generated array:\n");

            for (int y = 0; y < j; y++)
            {
                for (int x = 0; x < i; x++)
                {
                    arr[x, y] = rand.Next(0, 10);

                    Console.WriteLine($"[{x},{y}]:{arr[x,y]} ");

                    if ((x+y)%2==0)
                    {
                        even_sum += arr[x, y];

                    }
                }

            }

            Console.WriteLine($"\nThe sum of even array indexed elements: {even_sum}");
            
        }


        static void Main(string[] args)
        {
            TwoDimension_Array();
        }
    }
}
