using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using CockroachRaces;
using CockroachRaces.DI;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(Startup))]
namespace CockroachRaces
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //Database.SetInitializer(new DropCreateDatabaseAlways<SportBetsContext>());
            // Code that runs on application startup





            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            var container = AutofacConfiguration.Configure();

            ConfigureAuth(app, container);



            //CORS

            var cors = new EnableCorsAttribute("*", "*", "*");
            GlobalConfiguration.Configuration.EnableCors(cors);
        }
    }
}