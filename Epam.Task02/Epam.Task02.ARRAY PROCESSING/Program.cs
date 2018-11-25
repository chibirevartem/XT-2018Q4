using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.ARRAY_PROCESSING
{
    class Program
    {
        static void Array_Processing()
        {
            Random rand = new Random();
            int length = rand.Next(20);
            int[] arr = new int[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = rand.Next(100);

            }

            Console.WriteLine($"Generated array:\n");

            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            int min = arr[0];
            int max = arr[0];

            for (int i = 0; i < length-1; i++)
            {
                if (arr[i + 1] > max)
                {
                    max = arr[i + 1];
                }

                else if (arr[i + 1] < min)
                {
                    min = arr[i + 1];
                }
            }

            Console.WriteLine($"\nMin:{min}\nMax:{max}");

            SortByNumber(arr);


        }
        
        public static void SortByNumber(int[] arr) //метод заимствовал из вступительного тестового задания
        {
            int length = arr.Length;

            int min_index; 
            int current_iteration = 0; 
            int temp = 0; 

            while (current_iteration < length - 1) 
            {
                for (int i = current_iteration + 1; i < length; i++) 
                {
                    if ((arr[i]) < (arr[current_iteration])) 
                    {
                        min_index = i; 

                        temp = arr[min_index];
                        arr[min_index] = arr[current_iteration];
                        arr[current_iteration] = temp;
                        
                    }
                }

                current_iteration++; 

            }

            Console.WriteLine($"Sorted Array:\n");

            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

        }


        static void Main(string[] args)
        {
            Array_Processing();
        }
    }
}
