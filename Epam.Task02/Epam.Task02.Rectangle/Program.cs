using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.Rectangle
{
    class Program
    {
        public static void Rectangle(double a, double b)
        {
            if ((a>0.0)&(b>0.0))
            {
                Console.WriteLine($"The area is: {a*b}");
            }

            else { Console.WriteLine("Both sides must be positive"); }
        }
        static void Main(string[] args)
        {
            
            while (true)
            {
                double a, b;

                Console.Write("\nThis is a rectangle-area calculator\n\n");
                
                Console.Write($"Please,type in the A-side and press ENTER( , - separator):");
                bool success1 = double.TryParse(Console.ReadLine(),out a);
               

                Console.Write("Please,type in the B-side and press ENTER( , - separator):");
                bool success2 = double.TryParse(Console.ReadLine(), out b);
                
                if (success1 & success2) { Rectangle(a, b); }
                else { Console.WriteLine("Wrong input data.Try again"); }

            }
            
        }
    }
}
