using System;
using CockroachRaces.BLL.Entities;
using CockroachRaces.DAL.EntitiesContext;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CockroachRaces.Managers
{
    public class ApplicationRoleStore : RoleStore<Role, Guid, UserRole>
    {
        public ApplicationRoleStore(ApplicationContext context) : base(context)
        {
        }
    }
}