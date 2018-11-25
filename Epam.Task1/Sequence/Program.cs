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

            else { Console.WriteLine("Error!\nThe number must be positive"); }

        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("It generates sequence from 1 to N in ascending order with step 1\nPlease, type in any positive number and press ENTER:");

                int n;
                bool result = Int32.TryParse(Console.ReadLine(), out n);

                if (result) { Sequence(n); }
                else { Console.WriteLine("Incorrect input data or the value is too much"); }
            }
            
        }
    }
}
