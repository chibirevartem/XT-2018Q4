using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._4.NumberArraySum
{

    static class ExtensionClass
    {
        public static int ArraySum(this int[] arr)
        {
            int sum = 0;
            for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        public static double ArraySum(this double[] arr)
        {
            double sum = 0;
            for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        public static double ArraySum(this float[] arr)
        {
            float sum = 0;
            for (int i = arr.GetLowerBound(0); i <= arr.GetUpperBound(0); i++)
            {
                sum += arr[i];
            }
            return sum;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {1,2,3,5,6 };

            var result = arr.ArraySum();

            float[] farr = new float[] { 1.0F, 2.0F, 3.0F, 5.0F, 6.0F };

            var fresult = farr.ArraySum();
        }
    }
}
