using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Epam.Task07.Entities;
using Epam.Task07.txtDAL.Interfaces;
using System.Configuration;


namespace Epam.Task07.txtDAL
{
    public class AwardsDAO: IAwardsDAO
    {
        private static char separator = '|';
        private string maxIdFilePath;
        private string awardsFilePath;
        private int maxId;

        public AwardsDAO()
        {
            maxIdFilePath = ConfigurationManager.AppSettings["TextFileDALAwardsIdKey"];
            awardsFilePath = ConfigurationManager.AppSettings["TextFileDALAwardsKey"];

            try
            {
                maxId = int.Parse(File.ReadAllText(maxIdFilePath));
            }
            catch (Exception)
            {

                maxId = 0;
            }
        }

        public bool Add(Award award)
        {
            award.Id = ++maxId;
            try
            {
                File.WriteAllText(maxIdFilePath,maxId.ToString());
                File.AppendAllLines(awardsFilePath, new[] {ToText(award)});
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                var awardId = GetAll().ToList().FirstOrDefault(awId => awId.Id == id);
                if (awardId == null)
                {
                    return false;
                }
                else
                {
                    GetAll().ToList().Remove(awardId);
                    File.WriteAllLines(awardsFilePath,GetAll().ToList().Select(ToText));
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool RemoveAll()
        {
            try
            {
                File.WriteAllText(awardsFilePath,"");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private string ToText(Award award)
        {
            return $"{award.Id}{separator}{award.Title}";
        }

        public IEnumerable<Award> GetAll()
        {
            try
            {
                return File.ReadAllLines(awardsFilePath).Select
                    (line=>
                    {
                        var found = line.Split(new[] { separator }, 2);
                        return new Award
                        {
                            Id = int.Parse(found[0]),
                            Title = found[1],
                        };
                    }
                    );
            }
            catch (Exception)
            {

                return Enumerable.Empty<Award>();
            }  
        }
    }
}
