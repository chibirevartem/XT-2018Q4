using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03.My_String
{
    class Program
    {

        static void Main(string[] args)
        {
            char[] char_array = new char[] { 'a', 'b', 'c' };
            string str = "abc";

            Console.Write($"char_array: ");

            for (int i = 0; i < char_array.Length; i++)
            {
                Console.Write($"{char_array[i]} ");
            }

            Console.WriteLine($"\nString: {str}");

            MyString mstr = new MyString(str);

            Console.WriteLine($"Index of 'b': {mstr.IndexOf('b')}");

            Console.WriteLine($"Result of compare string  to array:{mstr.CompareTo(char_array)}");

            char[] appended = mstr.Append(char_array);

            Console.Write($"Append string with arr:");

            for (int i = 0; i < appended.Length; i++)
            {
                Console.Write($"{appended[i]}");
            }
            Console.WriteLine("");

            var str1 = mstr.ToString();

            string str2 = mstr;

          
            
        }
    }
}
