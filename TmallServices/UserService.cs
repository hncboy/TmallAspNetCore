using System;
using System.Collections.Generic;
using Tmall.Core.IRepository;
using Tmall.Core.IServices;
using Tmall.Core.Model;
using Tmall.Core.Utils;

namespace Tmall.Core.Services
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

        public User Get(string name, string password)
        {
            return userRepository.Get(name, password);
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public PageNavigator<User> List(int start, int size, int navigatePages)
        {
            List<User> allUserList = userRepository.List();
            List<User> pageUserList = userRepository.List(start, size);
            Page<User> page = PageUtil<User>.CalcPage(start, size, navigatePages, pageUserList, allUserList);
            return new PageNavigator<User>(page);
        }
    }
}
