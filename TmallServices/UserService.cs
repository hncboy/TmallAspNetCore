using System;
using TmallAspNetCore.IRepository;
using TmallAspNetCore.IServices;
using TmallAspNetCore.Model;

namespace TmallAspNetCore.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

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
