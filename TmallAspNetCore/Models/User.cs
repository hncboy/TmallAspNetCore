using SqlSugar;

namespace TmallAspNetCore.Model
{
    public class User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
