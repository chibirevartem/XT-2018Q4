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
            if (N > 0)
            {
                bool result = (N % 2) == 0;
                if (result)
                {
                    Console.WriteLine(N + " is a simple");
                }

                else Console.WriteLine(N + " is not a simple");
            }

        }


        static void Main(string[] args)
        {
            Simple(7);
            Simple(8);
            Console.ReadKey();
        }
    }
}
