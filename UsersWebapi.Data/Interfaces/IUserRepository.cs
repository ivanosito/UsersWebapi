using System;
using System.Collections.Generic;
using System.Text;
using UsersWebapi.Data.Models;

namespace UsersWebapi.Data.Interfaces
{
    public interface IUserRepository
    {
        bool Create(User user);
        User Retrieve(int id);
        List<User> RetrieveAll();
        bool Update(User user);
        bool Delete(int id);
    }
}
