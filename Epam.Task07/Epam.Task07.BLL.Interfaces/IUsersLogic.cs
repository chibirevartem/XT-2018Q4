using System.Collections.Generic;
using Epam.Task07.Entities;

namespace Epam.Task07.BLL.Interfaces
{
    public interface IUsersLogic
    {
        bool Add(string userName, string birthDate);
        IEnumerable<User> GetAll();
        bool Remove(int userId);
        bool RemoveAll();
    }
}