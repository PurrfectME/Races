using System;
using CockroachRaces.BLL.Entities;
using Microsoft.AspNet.Identity;

namespace CockroachRaces.Managers
{
    public class ApplicationRoleManager : RoleManager<Role, Guid>
    {
        public ApplicationRoleManager(IRoleStore<Role, Guid> store) : base(store)
        {
        }
    }
}