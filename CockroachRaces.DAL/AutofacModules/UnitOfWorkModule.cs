using Autofac;
using CockroachRaces.DAL.Repositories;

namespace CockroachRaces.DAL.AutofacModules
{
    public class UnitOfWorkModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
