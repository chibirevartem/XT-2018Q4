using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Epam.Task07.Entities;
using Epam.Task07.txtDAL;


namespace Epam.Task07.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";
        private const string AllAwardsCacheKey = "GetAllAwards";
        private const string DateFormat = "yyyy-MM-dd";
        private const string userNamePattern = @"^[A-Za-z0-9]+(?:[ _-][A-Za-z0-9]+)*$";
        private const string datePattern = @"^[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$";
        private readonly IUsersDAO usersDAO;
        private readonly ICacheLogic cacheLogic;
        private readonly IAwardUsersLogic awardUsersLogic;

        public UsersLogic(IUsersDAO usersDAO, ICacheLogic cacheLogic, IAwardUsersLogic awardUsersLogic)
        {
            this.awardUsersLogic = awardUsersLogic;
            this.cacheLogic = cacheLogic;
            this.usersDAO = usersDAO;
        }

        public bool Add(string userName, string birthDate)
        {
            if (!Regex.IsMatch(userName, userNamePattern))
            {
                throw new Exception("Incorrent username");
                
            }
            if (!Regex.IsMatch(birthDate, datePattern))
            {
                throw new Exception("Incorrent date");
            }

            User user = new User
            {
                Name = userName,
                BirthDate = DateTime.Parse(birthDate),
                //BirthDate = DateTime.ParseExact(birthDate, DateFormat, CultureInfo.InvariantCulture),
            };

            if (!(user.Age > 5 & user.Age < 150))
            {
                return false;
            }
            else
            {
                try
                {
                    cacheLogic.Delete(AllUsersCacheKey);
                    usersDAO.Add(user);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = cacheLogic.Get<IEnumerable<User>>(AllUsersCacheKey);

            if (cacheResult == null)
            {
                var users = usersDAO.GetAll().ToArray();

                foreach (User user in users)
                {
                    user.UserAwards  = awardUsersLogic.GetAwards(user.Id);
                }

                cacheLogic.Add(AllUsersCacheKey, users);

            }
            return cacheResult;
        }

        public bool Remove(int userId)
        {
            cacheLogic.Delete(AllAwardsCacheKey);
            cacheLogic.Delete(AllUsersCacheKey);
            return usersDAO.Remove(userId);
        }

        public bool RemoveAll()
        {
            cacheLogic.Delete(AllAwardsCacheKey);
            cacheLogic.Delete(AllUsersCacheKey);
            return usersDAO.RemoveAll();
        }
    }
}
