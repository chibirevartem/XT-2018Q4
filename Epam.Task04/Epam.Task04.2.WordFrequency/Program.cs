using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._2.WordFrequency
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string input = "This is my world. My new World";
            WordFrequency wf = new WordFrequency(input);
            wf.Results_ToConsole();
        }
    }
}
