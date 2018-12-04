using System.Data.Entity;
using Autofac;
using CockroachRaces.BLL.Entities;
using CockroachRaces.DAL.EntitiesContext;

namespace CockroachRaces.DAL.AutofacModules
{
    public class ContextModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerLifetimeScope();
            builder.Register(ctx => ctx.Resolve<ApplicationContext>().Bets).As<IDbSet<Bet>>().InstancePerLifetimeScope();
            builder.Register(ctx => ctx.Resolve<ApplicationContext>().Cockroaches).As<IDbSet<Cockroach>>().InstancePerLifetimeScope();
            builder.Register(ctx => ctx.Resolve<ApplicationContext>().Races).As<IDbSet<Race>>().InstancePerLifetimeScope();
            builder.Register(ctx => ctx.Resolve<ApplicationContext>().Users).As<IDbSet<User>>().InstancePerLifetimeScope();

           
        }
    }
}
