using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersWebapi.Data.Interfaces;
using UsersWebapi.Data.Models;

namespace UsersWebapi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Datos de prueba
        public List<User> users = new List<User>()
        {
            new User{ id=1, Name="Abel", LastName="Abaunza", Address="Calle 1 # 1-1", CreateDate=new DateTime(2019, 08, 01, 12, 30, 00), UpdateDate=DateTime.Now},
            new User{ id=2, Name="Beto", LastName="Borrero", Address="Calle 2 # 2-2", CreateDate=new DateTime(2019, 08, 02, 12, 30, 00), UpdateDate=DateTime.Now},
            new User{ id=3, Name="Carlo", LastName="Correa", Address="Calle 3 # 3-3", CreateDate=new DateTime(2019, 08, 03, 12, 30, 00), UpdateDate=DateTime.Now},
            new User{ id=4, Name="Dabeiba", LastName="Díaz", Address="Calle 4 # 4-4", CreateDate=new DateTime(2019, 08, 04, 12, 30, 00), UpdateDate=DateTime.Now},
            new User{ id=5, Name="Erik", LastName="Estévez", Address="Calle 5 # 5-5", CreateDate=new DateTime(2019, 08, 05, 12, 30, 00), UpdateDate=DateTime.Now}
        };

        // CRUD
        public bool Create(User user)
        {
            user.CreateDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            users.Add(user);
            return true;
        }

        public User Retrieve(int id)
        {
            var hallado = users.FirstOrDefault(x => x.id == id);
            return hallado;
        }

        public List<User> RetrieveAll()
        {
            return users;
        }

        public bool Update(User user)
        {
            var UpdatedUser = users.FirstOrDefault(x => x.id == user.id);
            if(UpdatedUser != null)
            {
                UpdatedUser.Name = user.Name;
                UpdatedUser.LastName = user.LastName;
                UpdatedUser.Address = user.Address;
                UpdatedUser.CreateDate = user.CreateDate;
                UpdatedUser.UpdateDate = DateTime.Now;
            }
            return true;
            //return this.RetrieveAll();
        }
        public bool Delete(int id)
        {
            var userAborrar = users.FirstOrDefault(x => x.id == id);
            if(userAborrar != null)
            {
                return users.Remove(userAborrar);
            }
            return false;
        }

    }
}
