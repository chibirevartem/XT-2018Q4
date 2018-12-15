using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task5._4._3.SortingUnit
{
    class Program
    {
        
         class SortingUnit
        {
            public delegate bool Comparator<T>(T first, T second);
            public delegate void MethodContainer();
            public event MethodContainer sort_finish;

            public bool Compare(int first, int second)
            {
                bool result = false;
                bool condition = first > second;

                if (condition)
                {
                    result = true;
                }

                return result;
            }

             public bool Compare(float first, float second)
            {
                bool result = false;
                bool condition = first > second;

                if (condition)
                {
                    result = true;
                }

                return result;
            }

              public bool Compare(double first, double second)
            {
                bool result = false;
                bool condition = first > second;

                if (condition)
                {
                    result = true;
                }

                return result;
            }
              public T[] BubbleSort<T>(ref T[] arr, Comparator<T> compare)
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
                return arr;
                
             }

            public T[] Thread_BubbleSort<T>( T[] arr, Comparator<T> compare)
            {
                if (arr != null)
                {
                    Thread thread = new Thread(() => BubbleSort(ref arr, compare));
                    thread.Start();
                    
                    sort_finish();
                    return arr;
                }

                else throw new Exception("Null reference error");

            }

        }

        class Handler
        {
            public void Message()
            {
                Console.WriteLine("The sorting has been passed");
            }
        }

        static void Main(string[] args)
        {
            SortingUnit first_unit = new SortingUnit();
            SortingUnit second_unit = new SortingUnit();

            Handler handler = new Handler();

            first_unit.sort_finish += handler.Message;
            second_unit.sort_finish += handler.Message;


            int[] first_arr = new int[] { 5, 6, 8, 9, 1, 2, 7, 3, 4 };
            int[] second_arr = new int[] { 5, 6, 8, 9, 1, 2, 7, 3, 4, 105,107,108 };


            var first = first_unit.Thread_BubbleSort(first_arr, first_unit.Compare);
            var second = second_unit.Thread_BubbleSort(second_arr, second_unit.Compare);

        }
    }
}
