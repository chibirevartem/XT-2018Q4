using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    class Program
    {
        static void Sequence(int N)
        {
            if (N > 0)
            {
                int[] arr = new int[N];
                for (int i = 0; i < N; i++)
                {
                    arr[i] = i + 1;

                    Console.Write(arr[i] + " ");
                }

                Console.WriteLine();

            }

        }
        static void Main(string[] args)
        {
            Sequence(7);
            Console.ReadKey();
        }
    }
}
