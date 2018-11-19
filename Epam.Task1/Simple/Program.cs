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


        static void Main(string[] args) // не доделан интерфейс
        {

            Console.WriteLine("This is a Simple-number test. Please, type in any number you want to check and press ENTER.");

            int n;
            bool result = Int32.TryParse(Console.ReadLine(), out n);

            if (result) { Simple(n); }
            else { Console.WriteLine("Incorrect input data"); }
            
            
        }
    }
}
