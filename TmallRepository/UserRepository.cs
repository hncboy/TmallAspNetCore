using SqlSugar;
using System.Collections.Generic;
using Tmall.Core.IRepository;
using Tmall.Core.Model;
using Tmall.Core.Repository.sugar;
using Tmall.Core.Utils;

namespace Tmall.Core.Repository
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

        public void Add(User user)
        {
            throw new System.NotImplementedException();
        }

        public User FindByName(string name)
        {
            return db.Queryable<User>().First();
        }

        public User Get(string name, string password)
        {
            return db.Queryable<User>().Where(it => it.Name == name && it.Password == password).First();
        }

        public List<User> List(int start, int size) {
            return db.Queryable<User>().OrderBy(it => it.Id).ToPageList(start, size);
        }

        public List<User> List()
        {
            return db.Queryable<User>().OrderBy(it => it.Id).ToList();
        }
    }
}
