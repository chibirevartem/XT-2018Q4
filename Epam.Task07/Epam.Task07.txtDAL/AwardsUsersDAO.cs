using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Epam.Task07.Entities;

namespace Epam.Task07.txtDAL
{
    public class AwardsUsersDAO : IAwardsUsersDAO
    {
        private static char separator = '|';
        private string awardUsersFilePath;

        public AwardsUsersDAO()
        {
            awardUsersFilePath = ConfigurationSettings.AppSettings["TextFileDALAwardUsersKey"];
        }

        public bool Add(AwardUser awardUser)
        {
            try
            {
                File.AppendAllLines(awardUsersFilePath, new[] {ToText(awardUser)});
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private static string ToText(AwardUser awardUser)
        {
            return $"{awardUser.UserId.ToString()}{separator}{awardUser.AwardId.ToString()}{separator}";
        }

        public IEnumerable<AwardUser> GetAll()
        {
            try
            {
                return File.ReadAllLines(awardUsersFilePath).Select
                    (
                    line=> 
                    {
                        var found = line.Split(new[] { separator }, 2);
                        return new AwardUser
                        {
                            UserId = int.Parse(found[0]),
                            AwardId = int.Parse(found[1]),
                        };

                    }
                    );
            }
            catch (Exception)
            {

                return Enumerable.Empty<AwardUser>();
            }
        }
    }
}
