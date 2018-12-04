using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Autofac;
using CockroachRaces.BLL.Entities;
using CockroachRaces.DAL.EntitiesContext;
using CockroachRaces.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace CockroachRaces.AutofacModules
{
    public class ManagersModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //User Manager
            builder.RegisterType<ApplicationUserManager>();
            builder.Register(ctx =>
                    new UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>(ctx.Resolve<ApplicationContext>()))
                .As<IUserStore<User, Guid>>()
                .InstancePerLifetimeScope();

            //SignIn Manager
            builder.RegisterType<ApplicationSignInManager>();
            builder.RegisterType<AuthenticationManager>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.Register(ctx => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>()
                .InstancePerLifetimeScope();

            //Role Manager
            builder.Register(ctx => new RoleStore<Role, Guid, UserRole>(ctx.Resolve<ApplicationContext>()))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<RoleManager<Role, Guid>>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<ApplicationRoleManager>();
        }
    }
}