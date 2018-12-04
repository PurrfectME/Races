using System.Web.Mvc;

namespace CockroachRaces.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/action/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}