using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03.My_String
{
    class MyString
    {
        char[] arr;
        public MyString(string input)
        {
            Length = input.Length;
            arr = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = input[i];
            }

        }
        public int Length { get; private set; }

        public MyString(char[] input)
        {
            arr = input;

        }

        public bool CompareTo(char[] input)
        {
            bool result = false;
            if (arr.Length == input.Length)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    result = arr[i] == input[i];
                    if (!result)
                    {
                        break;
                    }
                }

            }

            return result;
        }

        public int IndexOf(char symbol)
        {
            int index = -1; // if it has not not found;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == symbol)
                {
                    index = i;
                    break;
                }

            }

            return index;
        }

        public char[] Append(char[] input)
        {
            char[] output = new char[arr.Length + input.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                output[i] = arr[i];

            }
            for (int j = arr.Length, i = 0; j < output.Length; j++, i++)
            {
                output[j] = arr[i];
            }

            return output;
        }

        public override string ToString()
        {
            return new string(arr);
        }

        public static implicit operator String(MyString mystring)
        {
            return new string(mystring.arr);
        }

        public Char this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }

        }

    }
}
