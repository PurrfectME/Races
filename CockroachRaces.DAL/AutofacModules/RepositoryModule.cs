using Autofac;
using CockroachRaces.BLL.Entities;
using CockroachRaces.DAL.Repositories;

namespace CockroachRaces.DAL.AutofacModules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repository<Bet>>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repository<Cockroach>>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repository<Race>>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<Repository<User>>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
