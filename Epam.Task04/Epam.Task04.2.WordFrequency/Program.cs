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
            string input = "My family.Meet my family.There are five of us – my parents, my elder brother,my baby sister and me. First, meet my mum and dad.";
            WordFrequency wf = new WordFrequency(input);
            wf.Results_ToConsole();
        }
    }
}
