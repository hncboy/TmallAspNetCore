using System;
using TmallAspNetCore.IRepository;
using TmallAspNetCore.Model;

namespace TmallAspNetCore.Repository
{
    public class UserRepository : IUserRepository
    {
        public User FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public User GetByNameAndPassword(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
