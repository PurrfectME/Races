using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CockroachRaces.BLL.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        [Key]
        public int Key { get; set; }
    }

    public class UserLogin : IdentityUserLogin<Guid>
    {
        [Key]
        public int Key { get; set; }
    }

    public class UserClaim : IdentityUserClaim<Guid>
    {

    }

    public class Role : IdentityRole<Guid, UserRole>
    {

    }

    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        public double Balance { get; set; }
        //public Cockroach Cockroach { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, Guid> manager,
            string authenticationType)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
