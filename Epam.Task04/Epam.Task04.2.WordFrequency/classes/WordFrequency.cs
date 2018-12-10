using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._2.WordFrequency
{
    class WordFrequency
    {
        string input;
        string[] output;
        List<string> list;
        Dictionary<string, int> check_result;


        char[] ignored_symbols = { ' ', '.' };

        List<string> dismatches = new List<string>();
        public WordFrequency(string text)
        {
            if (text != null)
            {
                input = text;

                list = new List<string>();
                output = input.Split(ignored_symbols, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < output.Count(); i++)
                {
                    char[] charray = output[i].ToArray();
                    string this_word = "";

                    for (int j = 0; j < charray.Length; j++)
                    {
                        char this_symbol = charray[j];

                        if (char.IsLetter(this_symbol))
                        {
                            this_word += char.ToLower(this_symbol);
                        }
                    }
                    list.Add(this_word);
                }

                Repeatability_check();
            }



        }

        public void Results_ToConsole()
        {
            Console.WriteLine($"The text is : {input}\n");
            foreach (KeyValuePair<string, int> value in check_result)
            {
                Console.WriteLine($"{value.Key.ToString()}: repeats {value.Value.ToString()} times.");
            }
        }

        public void Repeatability_check()
        {
            check_result = new Dictionary<string, int>();

            for (int i = 0; i < list.Count; i++)
            {
                int matches = 0;


                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        matches++;
                        list.RemoveAt(j);
                    }
                }
                check_result.Add(list[i], matches);


            }
        }

    }
}
