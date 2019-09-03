using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UsersWebapi.Data.Interfaces;
using UsersWebapi.Data.Models;
using UsersWebapi.Data.Repositories;

namespace UsersWebapi.Controllers
{
    public class UsersController : ApiController
    {
        //IUserRepository _repository = new UserRepository();
        IUserRepository _repository;

        // Inyección de Dependencia
        public UsersController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return _repository.RetrieveAll();
        }

        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            var user = _repository.Retrieve(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
            //return "value";
        }

        // POST: api/Users -- Create
        public bool Post([FromBody]User user)
        {
            return _repository.Create(user);
        }

        // PUT: api/Users/5 -- Update
        public bool Put(int id, [FromBody]User user)
        {
            user.id = id;
            return _repository.Update(user);
        }

        // DELETE: api/Users/5
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
