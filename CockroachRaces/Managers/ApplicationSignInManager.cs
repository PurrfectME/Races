using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CockroachRaces.BLL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CockroachRaces.Managers
{
    public class ApplicationSignInManager : SignInManager<User, Guid>
    {
        public ApplicationSignInManager(UserManager<User, Guid> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }


        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager, AuthenticationType);
        }

       
    }
}