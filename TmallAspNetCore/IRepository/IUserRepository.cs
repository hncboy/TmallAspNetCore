using System;
using TmallAspNetCore.Model;

namespace TmallAspNetCore.IRepository
{
    interface IUserRepository
    {
        User FindByName(String name);
        User GetByNameAndPassword(String name, String password);
    }
}
