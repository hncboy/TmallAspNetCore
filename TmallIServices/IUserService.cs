using Tmall.Core.Utils;
using Tmall.Core.Model;

namespace Tmall.Core.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// 根据用户名查询用户是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsExist(string name);

        /// <summary>
        /// 根据用户名查询用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User GetByName(string name);

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
        /// <param name="navigatePages"></param>
        /// <returns></returns>
        PageNavigator<User> List(int start, int size, int navigatePages);
    }
}
