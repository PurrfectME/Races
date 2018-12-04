using System;
using System.Data.Entity;
using CockroachRaces.BLL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CockroachRaces.DAL.EntitiesContext
{
    public class ApplicationContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public ApplicationContext() : base("CockroachString")
        {
            
        }

        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Cockroach> Cockroaches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
