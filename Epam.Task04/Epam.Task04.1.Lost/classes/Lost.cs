using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._1.Lost
{
    class Lost
    {
        List<int> list = new List<int>();
        public Lost(int length)
        {
            if (length > 0)
            {
                for (int i = 1; i <= length; i++)
                {
                    list.Add(i);
                }
            }
            else
            {
                throw new Exception("Index must be more than 0");
            }
        }

        public void ShowProcessbyConsole()
        {
            ShowList();

            bool IsSecond = false;
            while (list.Count > 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (IsSecond)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                    IsSecond = !IsSecond;
                }
                ShowList();

            }

        }

        private void ShowList()
        {
            foreach (var item in list)
                Console.Write($"{item} ");
            Console.WriteLine();
        }
    }
}
