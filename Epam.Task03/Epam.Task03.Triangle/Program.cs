using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03.Triangle
{
    class Program
    {
       
        static void Main(string[] args)
        {
            double A_side = 2.0;
            double B_side = 3.0;
            double C_side = 4.0;

            Triangle tr = new Triangle(A_side, B_side, C_side);
            Console.WriteLine($"A_side:{A_side}; B_side:{B_side}; C_side:{C_side};");
            Console.WriteLine($"Area:{tr.Get_Area} ; Perimeter: {tr.Get_Perimeter}");

            
        }
    }
}
