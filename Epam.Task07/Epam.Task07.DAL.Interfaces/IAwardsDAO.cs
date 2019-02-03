using System.Collections.Generic;
using Epam.Task07.Entities;


namespace Epam.Task07.txtDAL.Interfaces
{
    public interface IAwardsDAO
    {
        bool Add(Award award);
        IEnumerable<Award> GetAll();
        bool Remove(int id);
        bool RemoveAll();
    }
}