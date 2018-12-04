using System;
using CockroachRaces.BLL.Entities;

namespace CockroachRaces.Models
{
    public class RoleModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public RoleModel()
        {

        }

        public RoleModel(Role role)
        {
            Name = role.Name;
            Id = role.Id;
        }

        public static explicit operator Role(RoleModel role)
        {
            return new Role() {
                Id = role.Id,
                Name = role.Name
            };
        }


    }
}