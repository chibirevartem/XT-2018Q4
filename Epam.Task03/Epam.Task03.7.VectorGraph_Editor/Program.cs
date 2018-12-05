using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._7.VectorGraph_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int x0 = 0;
            int y0 = 0;
            int x1 = 5;
            int y1 = 10;
            Linea linea = new Linea(x0, y0, x1, y1);
            linea.Show_Info();
            Console.WriteLine("--------");
            int radius = 5;
            Circle circle = new Circle(x0,y0,radius);
            circle.Show_Info();
            Console.WriteLine("--------");
            Round round = new Round(x0, y0, radius);
            round.Show_Info();
            Console.WriteLine("--------");
            int inner_radius = 3;
            Ring ring = new Ring(x0, y0, radius, inner_radius);
            ring.Show_Info();

        }
    }
}
