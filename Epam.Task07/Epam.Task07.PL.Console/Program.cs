using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task07.BLL.Interfaces;
using Epam.Task07.Entities;
using Epam.Task07.PL.Console;
using Epam.Task07.Common;


namespace Epam.Task07.PL.Console
{
    internal class Program
    {
        internal static IUsersLogic usersLogic;
        internal static IAwardUsersLogic awardUsersLogic;
        internal static ICacheLogic cacheLogic;
        internal static IAwardsLogic awardsLogic;

        static void Main(string[] args)
        {
            usersLogic = DependencyResolver.UsersLogic;
            awardUsersLogic = DependencyResolver.AwardUsersLogic;
            cacheLogic = DependencyResolver.CacheLogic;
            awardsLogic = DependencyResolver.AwardsLogic;


            while (true)
            {
                ConsoleLogic.Run();
            }
        }
    }
}
