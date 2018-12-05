using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._7.VectorGraph_Editor
{
    abstract class Tetragon:Figure
    {

         public abstract double Perimeter { get; }
         public abstract double Area { get; }
         
    }

    class Rectangle : Tetragon
    {
        public double Height { get; set; }
        public double Weight { get; set; }

        public Rectangle(int x0, int y0, double height, double weight)
        {
            base.X0 = x0;
            base.Y0 = y0;
            Height = height;
            Weight = weight;


        }

        public override double Perimeter
        {
            get
            {
                return 2 * (Height+ Weight);
            }
        }

        public override double Area
        {
            get
            {
                return Height * Weight;
            }
        }

        public override void Show_Info()
        {
            Console.WriteLine($"X0:{X0};Y0:{Y0}");
            Console.WriteLine($"Height:{Height}");
            Console.WriteLine($"Weight:{Weight}");
            Console.WriteLine($"Perimeter:{Perimeter}");

        }
    }
}
