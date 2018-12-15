using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Epam.Task5._2.CustomSortDemo
{
    delegate bool Comparator<T>(T first, T second);
    class Program
    {
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
                for (int i = 0; i < first.Length ; i++)
                {
                    if (first.ToCharArray()[i] > second.ToCharArray()[i])
                    {
                        result = true; break;
                    }

                    if (first.ToCharArray()[i] < second.ToCharArray()[i])
                    {
                        result = false;break;
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
            string[] strarr = new string[] { "bacde", "bcdef", "abcde","aaaaaaaaa" };

            Console.WriteLine("Before sorting:\n");
            foreach (var item in strarr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("After sorting:\n");

            BubbleSort(ref strarr, Compare);
            foreach (var item in strarr)
            {
                Console.WriteLine($"{item}");
            }

            
        }
    }
}
