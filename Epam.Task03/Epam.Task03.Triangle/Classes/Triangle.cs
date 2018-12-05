using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03.Triangle
{
    class Triangle
    {
        private double A, B, C;
        private double p;
        private double Area, Perimeter;

        public Triangle(double a_side, double b_side, double c_side)
        {
            bool IsPositive = a_side > 0 & b_side > 0 & c_side > 0;
            bool IsValid = (a_side + b_side - c_side > 0) & (a_side + c_side - b_side > 0) & (b_side + c_side - a_side > 0);

            if (IsPositive & IsValid)
            {
                A = a_side;
                B = b_side;
                C = c_side;

                p = (A + B + C) / 2;

                Area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
                Perimeter = A + B + C;
            }
            else if (!IsPositive)
            {
                throw new Exception("All the sides must be positive");
            }

            else if (!IsValid)
            {
                throw new Exception("The triangle doesn't exist. A side is longer or equal to the sum of others.");
            }



        }

        public double Get_Area
        {
            get { return Area; }
        }

        public double Get_Perimeter
        {
            get { return Perimeter; }
        }
    }
}
