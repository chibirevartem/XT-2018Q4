using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Epam.Task04._3.DynamicArray
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            
            IEnumerable<int> collection = new int[3] { 1,2,3};

            DynamicArray<int> dynamic_array = new DynamicArray<int>(10);
            dynamic_array.AddRange(collection);
            dynamic_array.Insert(4, 3);

        }

        public void AddTest() // This is for testing. You can try it
        {
            DynamicArray<int> dynamic_array = new DynamicArray<int>();


            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"\n{i} iteration:");
                dynamic_array.Add(i);

                for (int j = 0; j < dynamic_array.Count; j++)
                {
                    Console.Write($"{dynamic_array[j]} ");
                }

                Console.Write($"Capacity:{dynamic_array.Capacity},Count:{dynamic_array.Count}");
            }

        }
    }
}
