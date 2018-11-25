using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.NON_NEGATIVE_SUM
{
    class Program
    {

        static void Non_negative_sum()
        {
            Random rand = new Random();

            int length = rand.Next(2, 10);
            int[] arr = new int[length];
            int buffer = 0;

            Console.WriteLine("Generated array:");
            for (int i = 0; i < length; i++)
            {
                arr[i] = rand.Next(-10, 10);

                Console.Write($"{arr[i]} ");

                if (arr[i] > 0) { buffer += arr[i]; }
            }

            Console.WriteLine($"\nNon negative sum is {buffer}");
        }
        static void Main(string[] args)
        {
            Non_negative_sum();
        }
    }
}
