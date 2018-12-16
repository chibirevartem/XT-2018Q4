using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Epam.Task5._6.ICQ
{
    class Program
    {
        delegate bool Comparison(int element);

        static List<int> GetPositive(int[] array)
        {
            List<int> result = new List<int>();

            foreach (int elem in array)
            {
                if (elem > 0) result.Add(elem);
            }

            return result;
        }

        static List<int> GetPositive_delegate(int[] array, Comparison comparison)
        {
            List<int> result = new List<int>();

            foreach (var item in array)
            {
                if (comparison.Invoke(item))
                { result.Add(item); }
            }

            return result;
        }


        static bool IsPositive(int element)
        {
            return (element>0);
        }
        static int[] Generate_Array(int length)
        {
            int[] array = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = rnd.Next(-100, 100);
            }
            return array;
        }



        class Measure
        {
            public string name;
            public List<int> result;
            public List<long> measurement_time = new List<long>();

            public Measure(string name_of_measure)
            {
                name = name_of_measure;
                
            }
        }

        static void Main(string[] args)
        {
           
            int array_length = 10000;
            int iteration = 1000;
            int[] array = Generate_Array(array_length);


            Measure direct_search = new Measure("direct_search");
            Measure delegate_search = new Measure("delegate_search");
            Measure anonymous_method_search = new Measure("anonymous_method_search");
            Measure lambda_search = new Measure("lambda_search");
            Measure LINQ_search = new Measure("LINQ_search_search");

            Stopwatch stop_watch = new Stopwatch();
            Comparison comparison = new Comparison(IsPositive);

            
            for (int i = 0; i < iteration; i++)
            {
                stop_watch.Reset();
                stop_watch.Start();

                direct_search.result = GetPositive(array);

                stop_watch.Stop();
                direct_search.measurement_time.Add(stop_watch.ElapsedMilliseconds);
            }


            for (int i = 0; i < iteration; i++)
            {
                stop_watch.Reset();
                stop_watch.Start();

                delegate_search.result = GetPositive_delegate(array, comparison);

                stop_watch.Stop();
                delegate_search.measurement_time.Add(stop_watch.ElapsedMilliseconds);

            }

            for (int i = 0; i < iteration; i++)
            {
                stop_watch.Reset();
                stop_watch.Start();

                anonymous_method_search.result = GetPositive_delegate(array, delegate(int element) { return element > 0; } );

                stop_watch.Stop();
                anonymous_method_search.measurement_time.Add(stop_watch.ElapsedMilliseconds);

            }

            for (int i = 0; i < iteration; i++)
            {
                stop_watch.Reset();
                stop_watch.Start();

                lambda_search.result = GetPositive_delegate(array, element=>element>0);

                stop_watch.Stop();
                lambda_search.measurement_time.Add(stop_watch.ElapsedMilliseconds);

            }

            for (int i = 0; i < iteration; i++)
            {
                stop_watch.Reset();
                stop_watch.Start();

                var result = from element in array
                        where element > 0
                        select element;

                LINQ_search.result = result.ToList();

                stop_watch.Stop();

                LINQ_search.measurement_time.Add(stop_watch.ElapsedMilliseconds);
            }

            Measure[] results = { direct_search,
                delegate_search ,
                anonymous_method_search ,
                lambda_search ,
                LINQ_search };

            foreach (var item in results)
            {
                Console.WriteLine($"{item.name}:{item.measurement_time.Average()}");
            }
        }
    }
}
