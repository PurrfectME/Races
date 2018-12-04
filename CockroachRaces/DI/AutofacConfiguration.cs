using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CockroachRaces.AutofacModules;
using CockroachRaces.BLL.AutofacModules;
using CockroachRaces.DAL.AutofacModules;

namespace CockroachRaces.DI
{
    public class AutofacConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            //HTTP configuration
            var config = GlobalConfiguration.Configuration;
            //Register Web Api 2 controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<FinderModule>();
            builder.RegisterModule<UnitOfWorkModule>();
            builder.RegisterModule<ContextModule>();

            //MANAGERS
            builder.RegisterModule<ManagersModule>();


            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}