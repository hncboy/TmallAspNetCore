using System;
using TmallAspNetCore.Model;

namespace TmallAspNetCore.IRepository
{
    interface IUserRepository
    {
        /// <summary>
        /// 根据用户名查询用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User FindByName(String name);

        /// <summary>
        /// 根据用户名和密码查询用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User GetByNameAndPassword(String name, String password);
    }
}
