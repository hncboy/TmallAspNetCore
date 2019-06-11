using System;
using TmallAspNetCore.IRepository;
using TmallAspNetCore.IServices;
using TmallAspNetCore.Model;
using TmallAspNetCore.Repository;

namespace TmallAspNetCore.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository = new UserRepository();

        public bool IsExist(string name)
        {
            User user = GetByName(name);
            return null != user;
        }

        public User GetByName(String name)
        {
            return userRepository.FindByName(name);
        }
    }
}
