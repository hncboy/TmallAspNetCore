using System;
using System.Collections.Generic;
using Tmall.Core.Model;
using Tmall.Core.Utils;

namespace Tmall.Core.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 根据用户名查询用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User FindByName(String name);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Get(string name, string password);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        void Add(User user);

        /// <summary>
        /// 分页查询用户
        /// </summary>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<User> List(int start, int size);

        /// <summary>
        /// 查询全部用户
        /// </summary>
        /// <returns></returns>
        List<User> List();
    }
}
