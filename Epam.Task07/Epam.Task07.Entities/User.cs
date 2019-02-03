using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.Task07.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age => GetAge();
        public IEnumerable<Award> UserAwards { get; set; }

        private int GetAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - BirthDate.Year;
            if (BirthDate > now.AddYears(-age)) { age--; }

            return age;
        }
    }
}
