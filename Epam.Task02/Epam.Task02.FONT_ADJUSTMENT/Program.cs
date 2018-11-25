using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.FONT_ADJUSTMENT
{
    class Program
    {

       [Flags]
        enum Font_Adjustment
        {
            
            None = 0x0,  //00000000 1
            Bold = 0x1, //00000001  2
            Italic = 0x2, //00000100 4
            Underline = 0x4, //00001000 8

        }
       
        


        static void Main(string[] args)
        {
            Font_Adjustment font = (Font_Adjustment)0; 

            while (true)
            {
                Console.WriteLine($"\nParameters of font:{font}");
                Console.WriteLine($"Type in Value and press ENTER:");
                Console.WriteLine($"1: Bold\n2: Italic\n3: Underline");
                int input;

                bool success = Int32.TryParse(Console.ReadLine(), out input);

               
                if ((success)&(input > 0)&(input<4))
                {

                    font ^= ((Font_Adjustment)(int)Math.Pow(2, input-1)); // XOR
                }
                else { Console.WriteLine("Incorrect input data"); }
            }


        }
    }
}
