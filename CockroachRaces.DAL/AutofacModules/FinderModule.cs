using Autofac;

namespace CockroachRaces.DAL.AutofacModules
{
    public class FinderModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.Name.EndsWith("Finder"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
