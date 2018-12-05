using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03._5.Employee
{
    class Program
    {
        // дописать вывод инфы
        static void Main(string[] args)
        {
            Employee employee = new Employee("Vasya", "Pupkin", "Petrovich", "02.12.1990", 28);
            employee.employment_date = "02.10.2013";
            employee.position = "Senior Pomidor Developer";

            employee.Show_All_Info();


            //Console.WriteLine($"{employee.experience}");
            //Console.WriteLine($"{employee.position}");

        }
    }
}
