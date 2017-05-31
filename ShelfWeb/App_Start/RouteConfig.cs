using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShelfWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "CompanyList", url: "Company", defaults: new { controller = "CompanyMag", action = "CompanyList" });

            routes.MapRoute(name: "CompanyInfo", url: "Company/{id}", defaults: new { controller = "CompanyMag", action = "CompanyInfo" });

            routes.MapRoute(name: "Person", url: "Personal", defaults: new { controller = "PersonalMag", action = "Person" });

            routes.MapRoute(name: "RequireAuditing", url: "RequireAud/{id}", defaults: new { controller = "RequireMag", action = "RequireAuditing" });

            routes.MapRoute(name: "RequireBidding", url: "RequireBid/{id}", defaults: new { controller = "RequireMag", action = "RequireBidding" });

            routes.MapRoute(name: "RequireList", url: "Require", defaults: new { controller = "RequireMag", action = "RequireList" });

            routes.MapRoute(name: "RequireRelease", url: "RequireRel", defaults: new { controller = "RequireMag", action = "RequireRelease" });

            routes.MapRoute(name: "ScheduleList", url: "Schedule", defaults: new { controller = "ScheduleMag", action = "ScheduleList" });

            routes.MapRoute(name: "Scheduledetial", url: "Schedule/{id}", defaults: new { controller = "ScheduleMag", action = "Scheduledetial" });

            routes.MapRoute(name: "SystemList", url: "System", defaults: new { controller = "SystemMag", action = "SystemList" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "ShelfWeb.Controllers" }
            );
        }
    }
}
