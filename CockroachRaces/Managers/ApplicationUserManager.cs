using System;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;
using Microsoft.AspNet.Identity;

namespace CockroachRaces.Managers
{
    public class ApplicationUserManager : UserManager<User, Guid>
    {
        public ApplicationUserManager(IUserStore<User, Guid> store) : base(store)
        {
        }

        
    }
}