using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._8.Game
{
    interface IEngine:ILocation
    {
        int StepX { get; set;}
        int StepY { get; set; }
    }
}
