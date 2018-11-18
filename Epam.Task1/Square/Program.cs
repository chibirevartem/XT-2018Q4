using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square
{
    class Program
    {
        static void Square(int N)
        {
            if ((N > 0) & ((N % 2) != 0))
            {
                char[,] arr = new char[N, N];
                int middle = (int)(N - 1) / 2;

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if ((i == middle) & (j == middle))
                        {
                            Console.Write(" ");
                        }

                        else { Console.Write("*"); }

                    }

                    Console.WriteLine("");
                }


            }
        }
        static void Main(string[] args)
        {
            Square(9);

            Console.ReadKey();
        }
    }
}
