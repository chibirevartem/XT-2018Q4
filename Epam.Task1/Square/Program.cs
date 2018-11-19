﻿using System;
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
            

            Console.WriteLine("This is a Square-Figure Builder.Please, type in an uneven size of the side and press ENTER.");

            int n;
            bool result = Int32.TryParse(Console.ReadLine(), out n);

            if (result)
            {
                if (n < 16) { Square(n); }
                else { Console.WriteLine("Error! Too much (maximum is 15)"); };
                
            }
            else { Console.WriteLine("Incorrect input data"); }

            Console.ReadKey();
        }
    }
}
