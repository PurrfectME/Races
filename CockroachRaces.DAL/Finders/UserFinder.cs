using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;
using CockroachRaces.BLL.InterfaceForFinders;

namespace CockroachRaces.DAL.Finders
{
    public class UserFinder : BaseFinder<User>, IUserFinder
    {
        public UserFinder(IDbSet<User> entity) : base(entity)
        {
        }

        public Task<List<User>> FindAllUsers()
        {
            return Find().ToListAsync();
        }
    }
}
