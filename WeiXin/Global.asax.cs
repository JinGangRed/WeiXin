using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WeiXin.App_Start;

namespace WeiXin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //加载系统配置
            Config.Initialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //log4net配置
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
