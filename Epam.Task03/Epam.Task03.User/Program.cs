using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task03.User
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            User user = new User("Артемий", "Лебедев", "Татьянович", "01.01.1990", 28);

            user.Show_All_Info();

        }
    }
}
