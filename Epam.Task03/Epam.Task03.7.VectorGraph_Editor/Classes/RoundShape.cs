using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._7.VectorGraph_Editor
{
    class RoundShape:Figure
    {
        public double Radius { get; set; }
        public override void Show_Info()
        {
        }
    }

    class Circle: RoundShape
    {
        public Circle(int x0, int y0, double radius)
        {
            base.X0 = x0;
            base.Y0 = y0;
            base.Radius = radius;

            Console.WriteLine($"X0:{X0},Y0:{Y0}");
            Console.WriteLine($"Radius:{Radius}");
        }
        
       
        
        public virtual double Circumference
        {
            get { return 2 * Math.PI * Radius; }
        }

        public override void Show_Info()
        {
            Console.WriteLine($"Type:Circle");
            Console.WriteLine($"Circumference:{Circumference}");
            
        }

    }

    class Round : Circle
    {
        public Round(int x0, int y0, double radius) : base(x0, y0, radius)
        {  
        }

        public virtual double Area
        {
            get { return Math.PI * Radius * Radius / 2; }
        }


        public override void Show_Info()
        {
            Console.WriteLine("Type:Round");
            Console.WriteLine($"Circumference:{Circumference}");
            Console.WriteLine($"Area:{Area}");
        }
    }

    class Ring:Round
    {
        public double Inner_Radius { get; }

        public Ring(int x0, int y0, double radius, double inner_radius) : base(x0, y0, radius)
        {
            
            Inner_Radius = inner_radius;
        }

        public override double Circumference
        {
            get { return 2 * Math.PI * (Radius+ Inner_Radius); }
        }

        public override double Area
        {
            get { return Math.Abs(Math.PI * Radius * Radius / 2) - (Math.PI * Inner_Radius * Inner_Radius / 2); }
        }

        public override void Show_Info()
        {
            Console.WriteLine("Type:Ring");
            Console.WriteLine($"Inner Radius:{Inner_Radius}");
            Console.WriteLine($"Total Circumference:{Circumference}");
            Console.WriteLine($"Area:{Area}");
        }
    }
}
