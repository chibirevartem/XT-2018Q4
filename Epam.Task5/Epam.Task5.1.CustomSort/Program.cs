using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._1.CustomSort
{

    delegate bool Comparator<T>(T first,T second);

    class Program
    {
        static public bool Compare(int first, int second)
        {
            bool result = false;
            bool condition = first > second ;

            if (condition)
            {
                result = true;
            }

            return result;
        }

        static public bool Compare(float first, float second)
        {
            bool result = false;
            bool condition = first > second;

            if (condition)
            {
                result = true;
            }

            return result;
        }

        static public bool Compare(double first, double second)
        {
            bool result = false;
            bool condition = first > second;

            if (condition)
            {
                result = true;
            }

            return result;
        }

        static public bool Compare(string first, string second)
        {
            bool result = false;
            bool condition = first.Length > second.Length;

            if (condition)
            {
                result = true;
            }

            else if (first.Length == second.Length)
            {
                for (int i = 0; i < first.Length-1; i++)
                {
                    if (first.ToCharArray()[i]> second.ToCharArray()[i])
                    {
                        result = false;
                    }

                    if (first.ToCharArray()[i] < second.ToCharArray()[i])
                    {
                        result = true;
                    }

                }
            }



            return result;
        }




        static public void BubbleSort<T>(ref T[] arr, Comparator<T> compare)
        {
            T temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (compare.Invoke(arr[i], arr[j]))
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }

            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] {5,6,8,9,1,2,7,3,4};
            foreach (var item in arr)
            {
                Console.Write($"{item}");
            }

            BubbleSort(ref arr, Compare);

            Console.WriteLine();

            foreach (var item in arr)
            {
                Console.Write($"{item}");
            }

            string[] strarr = new string[] { "abcde","bacde","bcdef"};
            BubbleSort(ref strarr, Compare);
            foreach (var item in strarr)
            {
                Console.WriteLine($"{item}");
            }

        }
    }
}
