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

                    if (i!=(N-1))
                    {
                        Console.Write(arr[i] + ", ");
                    }

                    else { Console.Write(arr[i] + "."); }
                    
                }

                Console.WriteLine();

            }

        }
        static void Main(string[] args)
        {

            Console.WriteLine("This is an array generator. Please, type in any positive number and press ENTER.");

            int n;
            bool result = Int32.TryParse(Console.ReadLine(), out n);

            if (result) { Sequence(n); }
            else { Console.WriteLine("Incorrect input data"); }

            Console.ReadKey();
        }
    }
}
