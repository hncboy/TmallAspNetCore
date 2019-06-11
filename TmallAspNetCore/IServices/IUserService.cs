using System;
using TmallAspNetCore.Model;

namespace TmallAspNetCore.IServices
{
    interface IUserService
    {
        /// <summary>
        /// 根据用户名查询用户是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsExist(String name);

        /// <summary>
        /// 根据用户名查询用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User GetByName(String name);
    }
}
