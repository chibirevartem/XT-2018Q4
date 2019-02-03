﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Epam.Task07.BLL.Interfaces;
using Epam.Task07.txtDAL.Interfaces;
using Epam.Task07.BLL;
using Epam.Task07.txtDAL;

namespace Epam.Task07.Common
{
    public class DependencyResolver
    {
        private static IAwardsDAO awardsDAO;
        private static IAwardsLogic awardsLogic;
        private static IUsersDAO usersDAO;
        private static IUsersLogic usersLogic;
        private static ICacheLogic cacheLogic;
        private static IAwardsUsersDAO awardsUsersDAO;
        private static IAwardUsersLogic awardUsersLogic;

        public static IAwardsDAO AwardsDAO
        {
           get
            {
                string key = ConfigurationSettings.AppSettings["AwardsDAOKey"];

                if (awardsDAO == null)
                {
                    if (key == "textfile")
                    {
                        awardsDAO = new AwardsDAO();

                    }
                }

                return awardsDAO;

            }
        }

        public static IAwardsLogic AwardsLogic
        {
            get
            {
                if (awardsLogic == null)
                {
                    awardsLogic = new AwardsLogic(awardsDAO,cacheLogic);
                }

                return awardsLogic;
            }
        }

        public static IUsersDAO UsersDAO
        {
            get
            {
                string key = ConfigurationSettings.AppSettings["UsersDAOKey"];

                if (usersDAO == null)
                {
                    if (key == "textfile")
                    {
                        usersDAO = new UsersDAO();
                    }
                }

                return usersDAO;
            }
        }

        public static IUsersLogic UsersLogic
        {
            get
            {
                if (usersLogic == null)
                {
                    usersLogic = new UsersLogic(usersDAO, cacheLogic, awardUsersLogic);
                }

                return usersLogic;
            }
        }

        public static ICacheLogic CacheLogic
        {
            get
            {
                if (cacheLogic == null)
                {
                    cacheLogic = new CacheLogic();
                }

                return cacheLogic;
            }
        }

        public static IAwardsUsersDAO AwardsUsersDAO
        {
            get
            {
                var key = ConfigurationSettings.AppSettings["AwardsUsersDAOKey"];

                if (awardsUsersDAO == null)
                {
                    if (key == "textfile")
                    {
                        awardsUsersDAO = new AwardsUsersDAO();
                    }
                }

                return awardsUsersDAO;
            }
        }

        public static IAwardUsersLogic AwardUsersLogic
        {
            get
            {
                if (awardUsersLogic == null)
                {
                    awardUsersLogic = new AwardUsersLogic(usersDAO, awardsDAO, awardsUsersDAO, cacheLogic);
                }

                return awardUsersLogic;
            }
        }
    }
}
