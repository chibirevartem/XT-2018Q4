using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.NO_POSITIVE
{
    class Program
    {
        static void Non_positive()
        {
            Random rand = new Random();
            int i = rand.Next(1,5);
            int j = rand.Next(1,5);
            int k = rand.Next(1,5);
            int[,,] arr = new int[i, j, k];


            Console.WriteLine("Before Changing:\n");

            Console.WriteLine($"i={i},j={j},k={k}");

            

            for (int z = 0; z < k; z++)
            {
                for (int y = 0; y < j; y++)
                {
                    for (int x = 0; x < i; x++)
                    {
                        arr[x, y, z] = rand.Next(-100, 100);

                        Console.WriteLine($"[{x},{y},{z}] = {arr[x,y,z]}");
                    }
                }
            }

            Console.WriteLine("\nAfter Changing:\n");

            for (int z = 0; z < k; z++)
            {
                for (int y = 0; y < j; y++)
                {
                    for (int x = 0; x < i; x++)
                    {
                        if (arr[x, y, z]>0) { arr[x, y, z] = 0; }

                        Console.WriteLine($"[{x},{y},{z}] = {arr[x, y, z]}");
                    }
                }
            }



        }
        static void Main(string[] args)
        {
            Non_positive();
        }
    }
}
