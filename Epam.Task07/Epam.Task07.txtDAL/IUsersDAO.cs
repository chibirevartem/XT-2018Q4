using System.Collections.Generic;
using Epam.Task07.Entities;

namespace Epam.Task07.txtDAL
{
    public interface IUsersDAO
    {
        void Add(User newUser);
        IEnumerable<User> GetAll();
        bool Remove(int userId);
        bool RemoveAll();
    }
}