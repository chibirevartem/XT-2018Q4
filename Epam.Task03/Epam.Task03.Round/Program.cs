using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03.Round
{
    class Program
    {
         
        static void Main(string[] args)
        {
            double radius = 5.0;
            Round r = new Round(radius);

            Console.WriteLine($"Radius:{radius}; Area:{r.Get_Area}; Circumference: {r.Get_Circumference}");
        }
    }
}
