using System.Collections.Generic;
using Epam.Task07.Entities;

namespace Epam.Task07.BLL
{
    public interface IAwardUsersLogic
    {
        bool AddAwardUser(int userId, int awardId);
        IEnumerable<Award> GetAwards(int userId);
    }
}