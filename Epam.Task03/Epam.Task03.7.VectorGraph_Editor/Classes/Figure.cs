using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._7.VectorGraph_Editor
{
    abstract class Figure
    {
         public int X0 { get; set; }
         public int Y0 { get; set; }
        public abstract void Show_Info();

    }

    class Linea : Figure
    {
        
        public int X1 { get; set; }
        public int Y1 { get; set; }


        public Linea(int x0, int y0, int x1, int y1)
        {
            X0 = x0;
            Y0 = y0;
            X1 = x1;
            Y1 = y1;
        }
        public  double Length
        {
            get { return Math.Sqrt((X1-X0)* (X1 - X0) + (Y1 - Y0) * (Y1 - Y0)); }
           
        }

        public override void Show_Info()
        {
            Console.WriteLine($"Type:Linea");
            Console.WriteLine($"X0:{X0};Y0:{Y0};X0:{X1};Y0:{Y1}");
            Console.WriteLine($"Length:{Length}");
        }

    }
}
