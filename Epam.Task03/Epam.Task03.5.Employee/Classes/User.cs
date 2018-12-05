using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._5.Employee
{
    class User
    {
        public string First_Name { get; private set; }
        public string Second_Name { get; private set; }
        public string Patronymic { get; private set; }
        public string DateOfBirth { get; } //реализовать проверку на ввод даты рождения
        public int Age { get; } // реализовать проверку на ввод возраста

        public User(string name, string surname, string patronymic, string dateofbirth, int age)
        {

            bool sucess1 = IsInfoValidated(name) & IsInfoValidated(surname) & IsInfoValidated(patronymic);
            bool sucess2 = IsAgeValidated(dateofbirth, age);

            if (sucess1 & sucess2)
            {
                First_Name = name;
                Second_Name = surname;
                Patronymic = patronymic;
                DateOfBirth = dateofbirth;
                Age = age;
            }

            else if (!sucess1)
            {
                throw new Exception("Incorrect info");
            }

            else if (!sucess2)
            {
                throw new Exception("Incorrect age");
            }

        }


        public bool IsInfoValidated(string info)
        {
            bool result = false;
            char[] ch_info = info.ToArray();

            for (int i = 0; i < ch_info.Length; i++)
            {
                result = char.IsLetter(ch_info[i]);
                if (!result) { break; }
            }
            return result;
        }

        public bool IsAgeValidated(string dateofbirth, int age)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTime date_value;

            bool result = false;
            int solved_age = 0;

            bool success = DateTime.TryParse(dateofbirth, out date_value);

            if (success)
            {
                DateTime now = DateTime.Now;

                solved_age = now.Year - date_value.Year;

                if (now.DayOfYear - date_value.DayOfYear < 0) { solved_age--; }
            }

            if (solved_age == age)
            {
                result = true;
            }

            return result;

        }

        public virtual void Show_All_Info()
        {
            Console.WriteLine($"First_Name : {First_Name}");
            Console.WriteLine($"Second_Name : {Second_Name}");
            Console.WriteLine($"Patronymic : {Patronymic}");
            Console.WriteLine($"DateOfBirth : {DateOfBirth}");
            Console.WriteLine($"Age: {Age}");
        }
    }
}
