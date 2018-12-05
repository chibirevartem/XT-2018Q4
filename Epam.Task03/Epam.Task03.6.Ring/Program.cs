using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._6.Ring
{
    class Program
    {
        static void Main(string[] args)
        {
            double inner_radius = 1.5;
            double outer_radius = 3.0;

            Ring r = new Ring(inner_radius, outer_radius);
            Console.WriteLine($"inner_radius:{inner_radius} ; outer_radius:{outer_radius}");
            Console.WriteLine($"Total Area:{r.Get_Area} (square units);\nTotal Circumference: {r.Get_TotalCircumference}");
        }
    }
}
