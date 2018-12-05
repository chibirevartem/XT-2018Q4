using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._8.Game
{
    class Bonus:IHealth,ILocation
    {
        enum Color
        {
            Red,
            Green,
            Yellow,
            White,
            Black
        }

        public int Health { get; set; }
        public int Armour { get; set; }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        

    }
}
