using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using Epam.Task07.Entities;
using Epam.Task07.txtDAL.Interfaces;

namespace Epam.Task07.txtDAL
{
    public class UsersDAO : IUsersDAO
    {
        private static string dateFormat = "yyyy-MM-dd";
        private static char separator = '|';
        private int maxId;
        private readonly string maxIdFilePath;
        private readonly string usersFilePath;

        public UsersDAO()
        {
            maxIdFilePath = ConfigurationSettings.AppSettings["TextFileDALUsersIdKey"];
            usersFilePath = ConfigurationSettings.AppSettings["TextFileDALUsersKey"];

            try
            {
                maxId = int.Parse(File.ReadAllText(this.maxIdFilePath));
            }
            catch (global::System.Exception)
            {

                maxId = 0;
            }
        }

        public void Add(User newUser)
        {
            newUser.Id = ++maxId;
            File.WriteAllText(maxIdFilePath, maxId.ToString());
            File.AppendAllLines(usersFilePath,new[] { ToText(newUser)});
        }

        private static string ToText(User newUser)
        {
            return $"{newUser.Id}{separator}{newUser.Name}{separator}{newUser.BirthDate.ToString(dateFormat)}";
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return File.ReadAllLines(usersFilePath)
                    .Select
                    (line => 
                    {
                        var found = line.Split(new[] { separator }, 3);
                        return new User
                        {
                            Id = int.Parse(found[0]),
                            Name = found[1],
                            BirthDate = DateTime.Parse(found[2])

                        };
                    }
                    );
            }
            catch (Exception)
            {

                return Enumerable.Empty<User>();
            }
        }

        public bool Remove(int userId)
        {
            var userIdToDelete = GetAll().ToList().FirstOrDefault(usr => usr.Id == userId);
            if (userIdToDelete == null)
            {
                return false;
            }
            else
            {
                GetAll().ToList().Remove(userIdToDelete);
                File.WriteAllLines(usersFilePath, GetAll().ToList().Select(ToText));
                return true;
            }

        }

        public bool RemoveAll()
        {
            try
            {
                File.WriteAllText(usersFilePath, " ");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
