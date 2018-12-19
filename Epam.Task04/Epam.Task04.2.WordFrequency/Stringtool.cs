using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._2.WordFrequency
{
    public class StringTool
    {
        

        public static string[] Get_Dismatches(string input) // метод принимает строку, выдаёт массив строк со словами, которые не повторяются в строке
        {

            char[] ignored_symbols = { ' ', ',', '.', '-', ':', '!', '?' }; // символы, которые игнорируем при разделении строки на слова

            List<string> dismatches = new List<string>(); // динамический список для внесения повторений

            string[] output = input.Split(ignored_symbols); //разделяем строку на слова, игнорируя ненужные символы

            string[] blacklist = new string[output.Length]; // в "черный список" попадают повторяющиеся слова

            for (int i = 0; i < (output.Length); i++) // цикл ищет повторения и формирует черный список
            {

                for (int j = i; j < (output.Length - 1); j++)
                {
                    if (output[i] == output[j + 1])
                    {
                        blacklist[i] = output[i];

                    }
                }
            }

            for (int i = 0; i < (output.Length); i++) // цикл сравнивает слова на соответствие черному списку
            {
                bool IsMatch = new bool();

                for (int j = 0; j < blacklist.Length; j++)
                {
                    if (output[i] == blacklist[j])
                    {
                        IsMatch = true;
                        break;
                    }
                }

                if (IsMatch != true) { dismatches.Add(output[i]); } // если слова нет в черном списке, формируем список слов "без совпадений"

            }
            string[] strout = new string[dismatches.Count()]; // отсюда идёт алгоритм приведения типа "список" в тип строкового массива

            for (int i = 0; i < strout.Length; i++)
            {
                strout[i] = dismatches[i];
            }

            return strout;
        }

    }
}
