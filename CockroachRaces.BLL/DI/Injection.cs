using Autofac;

namespace CockroachRaces.BLL.DI
{
    public class Injection
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            var container = builder.Build();
            return container;
        }
    }
}
