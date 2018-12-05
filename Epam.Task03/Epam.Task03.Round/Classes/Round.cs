﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03.Round
{
    class Round
    {
        private double X, Y, R;

        public Round(double radius, double x, double y)
        {

            if (radius > 0.0 )
            {
                X = x;
                Y = y;
                R = radius;
            }
            else
            {
                throw new Exception("Radius must be positive");
            }
        }

        public Round(double radius)
        {

            if (radius > 0.0)
            {
                X = 0.0;
                Y = 0.0;
                R = radius;
            }

            else
            {
                throw new Exception("Radius must be positive");
            }
        }

        public double Get_Circumference
        {
            get { return 2 * Math.PI * R; }
        }

        public double Get_Area
        {
            get { return Math.PI * R * R / 2; }
        }
    }
}
