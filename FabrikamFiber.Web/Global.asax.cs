namespace FabrikamFiber.Web
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Routing;

    using FabrikamFiber.DAL.Data;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                  "Default", // Route name
                  "{controller}/{action}/{id}", // URL with parameters
                  new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
              );
        }

        protected void Application_BeginRequest()
        {
            
        }

        protected void Application_Start()
        {
            Database.SetInitializer<FabrikamFiberWebContext>(new FabrikamFiberDatabaseInitializer());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}