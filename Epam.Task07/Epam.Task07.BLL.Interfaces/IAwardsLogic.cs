using System.Collections.Generic;
using Epam.Task07.Entities;

namespace Epam.Task07.BLL.Interfaces
{
    public interface IAwardsLogic
    {
        bool Add(string awardTitle);
        IEnumerable<Award> GetAll();
        bool Remove(int id);
        bool RemoveAll();
    }
}