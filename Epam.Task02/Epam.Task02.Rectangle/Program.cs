using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.Rectangle
{
    class Program
    {
        public static void Rectangle(int a, int b)
        {
            if ((a>0)&(b>0))
            {
                Console.WriteLine($"The Square is: {a*b}");
            }

            else { Console.WriteLine("Both sides must be positive"); }
        }
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("\nThis is a rectangle-square calculation\n");
                int a, b;
                Console.WriteLine("Please,type in A-side and press ENTER:");
                bool success1 = Int32.TryParse(Console.ReadLine(),out a);

                Console.WriteLine("Please,type in B-side and press ENTER:\n");
                bool success2 = Int32.TryParse(Console.ReadLine(), out b);

                if (success1 & success2) { Rectangle(a, b); }
                else { Console.WriteLine("Wrong input data.Try again"); }
                
            }
            
        }
    }
}
