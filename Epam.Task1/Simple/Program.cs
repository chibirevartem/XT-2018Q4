using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    class Program 
    {
        static void Simple(int N)
        {
            if (N >= 0)
            {
                bool result = (N % 2) == 0;
                if (result)
                {
                    Console.WriteLine(N + " is even");
                }

                else Console.WriteLine(N + " is not even");
            }

        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\nThis is an Even-number test.\nPlease, type in any number you want to check and press ENTER:");

                int n;
                bool result = Int32.TryParse(Console.ReadLine(), out n);

                if (result) { Simple(n); }
                else { Console.WriteLine("Incorrect input data or the number is too much"); }
            }
            
            
            
        }
    }
}
