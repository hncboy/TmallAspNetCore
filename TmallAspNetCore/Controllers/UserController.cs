using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TmallAspNetCore.Model;

/// <summary>
/// User 用户
/// </summary>
namespace TmallAspNetCore.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
        [HttpGet("/{id}")]
        public User GetUserByUserId(User user1)
        {
            User user = new User
            {
                Id = 1,
                Username = "hncboy",
                Password = "hncboy"
            };
            return user;
        }
    }
}
