using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._1.Lost
{
    class Program
    {
       
        static void Main(string[] args)
        {
            while (true)
            {
                int length;
                Console.WriteLine($"Please, type in a length:");
                bool success = int.TryParse(Console.ReadLine(), out length);
                if (success & length > 0)
                {
                    Lost test = new Lost(length);
                    test.ShowProcessbyConsole();
                }
            }

        }
    }
}
