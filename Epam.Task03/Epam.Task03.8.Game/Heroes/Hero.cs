using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._8.Game.Heroes
{
    class Hero : ILocation,IEngine,IHealth
    {
        string name { get; set; }

        public int StepX { get; set; }
        public int StepY { get; set; }
        public int Health { get; set; }
        public int Armour { get; set; }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        private void Move(int stepx,int stepy)
        {
            PositionX += stepx;
            PositionY += stepy;
        }

    }
}
