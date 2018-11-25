using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02.AverageStringLength
{
    class Program
    {

        public static void Average_Length(string input)
        {

            char[] charray = (input+".").ToCharArray();
            int buff = 0;
            int word = 0;

            for (int i = 0; i < charray.Length-1; i++)
            {
                if (char.IsLetter(charray[i]))
                {
                    buff++;
                }


                if ((char.IsLetter(charray[i]))&((char.IsSeparator(charray[i+1]))||(char.IsPunctuation(charray[i + 1]))))
                {
                    word++;
                }
            }
            Console.WriteLine($"Letter(s)={buff} ,word(s)={word},average letters per word = {buff/word}");
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please, write a phrase:");
            Average_Length(Console.ReadLine());
        }
    }
}
