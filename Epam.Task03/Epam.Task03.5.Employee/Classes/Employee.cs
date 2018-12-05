using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


// Исправить трабл с проверкой на должность

namespace Epam.Task03._5.Employee
{
    class Employee : User
    {
        public string employment_date
        {
            get { return this.employment_date; }
            set
            {
                Experience_calculator(value);
            }
        }
        public string experience { get; private set; }
        public string position
        { get; set; }


            /*
            get { return position;}

            set
            {
                if (IsPositionValidated(value))
                {
                    position = value;
                }
                else
                {
                    throw new Exception("Incorrect input");
                }

            }*/
        

       public void Experience_calculator(string employment_date)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTime date_value;

            bool success = DateTime.TryParse(employment_date, out date_value);
            if (success)
            {
                DateTime now = DateTime.Now;
                experience = $"{now.Year- date_value.Year} Years, {now.Month - date_value.Month} Months";
            }
        }

        // дописать проверку на стаж

        public bool IsPositionValidated(string position)
        {
            bool result = (position != null & position.Length<150);
            return result;
        }


        public Employee(string name, string surname, string patronymic, string dateofbirth, int age)
            : base( name,  surname,  patronymic, dateofbirth, age)
        {}

        public override void Show_All_Info()
        {
            Console.WriteLine($"First_Name : {base.First_Name}");
            Console.WriteLine($"Second_Name : {base.Second_Name}");
            Console.WriteLine($"Patronymic : {base.Patronymic}");
            Console.WriteLine($"DateOfBirth : {base.DateOfBirth}");
            Console.WriteLine($"Age: {base.Age}");
            Console.WriteLine($"Experience:{experience}");
            Console.WriteLine($"Position:{position}");
        }

    }
}
