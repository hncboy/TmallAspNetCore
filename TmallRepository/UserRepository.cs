using SqlSugar;
using System;
using TmallAspNetCore.IRepository;
using TmallAspNetCore.Model;
using TmallAspNetCore.Repository.sugar;

namespace TmallAspNetCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private DbContext context;
        private SqlSugarClient db;

        public UserRepository()
        {
            context = new DbContext();
            db = context.Db;
        }

        public User FindByName(string name)
        {
            return db.Queryable<User>().First();
        }

        public User GetByNameAndPassword(string name, string password)
        {
            return db.Queryable<User>().Where(it => it.Name == name && it.Password == password).First();
        }
    }
}
