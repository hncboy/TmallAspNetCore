﻿using Microsoft.AspNetCore.Mvc;
using System;

using TmallAspNetCore.IServices;
using TmallAspNetCore.Model;
using TmallAspNetCore.Utils;

namespace TmallAspNetCore.Controller
{
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
            string name = userParam.Name;
            try
            {
                User user = userService.GetByName(name);
                // TODO 将user存入session
                return Result.Success();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                string message = "账号密码错误";
                return Result.Fail(message);
            }
        }
    }
}
