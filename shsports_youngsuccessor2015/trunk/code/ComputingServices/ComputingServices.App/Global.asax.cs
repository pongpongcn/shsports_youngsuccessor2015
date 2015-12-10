using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;

namespace ComputingServices.App
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputingServices.Core.Infrastructure.Persistence.ComputingServicesContext, ComputingServices.Core.Migrations.Configuration>());
        }
    }
}