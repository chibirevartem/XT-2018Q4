using System.Collections.Generic;
using Epam.Task07.Entities;

namespace Epam.Task07.txtDAL.Interfaces
{
    public interface IAwardsUsersDAO
    {
        bool Add(AwardUser awardUser);
        IEnumerable<AwardUser> GetAll();
    }
}