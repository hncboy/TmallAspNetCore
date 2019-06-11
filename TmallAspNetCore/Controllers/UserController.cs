using Microsoft.AspNetCore.Mvc;
using System;

using Tmall.Core.IServices;
using Tmall.Core.Model;
using Tmall.Core.Utils;

namespace Tmall.Core.Controller
{
    /// <summary>
    /// 用户
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userParam">用户信息</param>
        /// <returns>登陆成功失败信息</returns>
        [HttpPost("/forelogin")]
        public Object Login(User userParam)
        {
            User user = userService.Get(userParam.Name, userParam.Password);
            if (user != null)
            {
                // TODO 将user存入session
                return Result.Success();
            }
            else
            {
                string message = "账号密码错误";
                return Result.Fail(message);
            }
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <param name="start"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet("/users")]
        public PageNavigator<User> List(int start = 0, int size = 5)
        {
            start = start < 0 ? 0 : start;
            return userService.List(start, size, 5);
        }
    }
}
