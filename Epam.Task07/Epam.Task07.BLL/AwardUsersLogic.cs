using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epam.Task07.Entities;
using Epam.Task07.txtDAL;

namespace Epam.Task07.BLL
{
    public class AwardUsersLogic : IAwardUsersLogic
    {
        private const string AllUsersCacheKey = "GetAllUsers";
        private const string AllAwardsCacheKey = "GetAllAwards";

        private readonly IUsersDAO usersDAO;
        private readonly IAwardsDAO awardsDAO;
        private readonly IAwardsUsersDAO awardsUsersDAO;
        private ICacheLogic cacheLogic;

        public AwardUsersLogic(IUsersDAO usersDAO, IAwardsDAO awardsDAO, IAwardsUsersDAO awardsUsersDAO, ICacheLogic cacheLogic)
        {
            this.usersDAO = usersDAO;
            this.awardsDAO = awardsDAO;
            this.awardsUsersDAO = awardsUsersDAO;
            this.cacheLogic = cacheLogic;
        }

        public bool AddAwardUser(int userId,int awardId)
        {
            var users = usersDAO.GetAll();
            var awards = awardsDAO.GetAll();

            var user = users.FirstOrDefault(usr => usr.Id== userId);
            var award = awards.FirstOrDefault(awrd => awrd.Id == awardId);

            if ( (user==null) & (award==null) )
            {
                return false;
            }
            else
            {
                AwardUser awardUser = new AwardUser { UserId = userId, AwardId = awardId, };

                if ( awardsUsersDAO.GetAll().Contains(awardUser) )
                {
                    throw new Exception("The user has already paired with the award"); 
                }
                else
                {
                    var result = awardsUsersDAO.Add(awardUser);

                    return result;
                }
            }

        }

        public IEnumerable<Award> GetAwards(int userId)
        {
            var awardsUser = awardsUsersDAO.GetAll();

            if (awardsUser.Any())
            {
                var awards = awardsDAO.GetAll();
                var awardsId = awardsUser.
                    Where(awrdsUs => awrdsUs.UserId == userId).
                    Select(awrdId=> awrdId.AwardId);

                return awards.Where(awds => awardsId.Contains(awds.Id));
            }
            else
            {
                return Enumerable.Empty<Award>();
            }

        }

    }
}
