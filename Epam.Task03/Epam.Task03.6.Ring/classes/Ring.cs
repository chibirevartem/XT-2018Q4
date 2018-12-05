using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._6.Ring
{
    class Ring
    {
        Round inner;
        Round outer;

        public Ring(double inner_radius, double outer_radius, int x, int y)
        {
            inner = new Round(inner_radius, x, y);
            outer = new Round(outer_radius, x, y);
        }
        public Ring(double inner_radius, double outer_radius)
        {
            inner = new Round(inner_radius);
            outer = new Round(outer_radius);
        }


        public double Get_Area
        {
            get
            {
                return Math.Abs(outer.Get_Area - inner.Get_Area);
            }
        }

        public double Get_TotalCircumference
        {
            get
            {
                return outer.Get_Circumference + inner.Get_Circumference;
            }
        }
    }
}
