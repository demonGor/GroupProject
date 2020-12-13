using API.Models;
using IoSContainers;
using Ninject;
using Ninject.Modules;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //Внедрение зависимостей
            
            NinjectModule DBModule = new DBModule("MyConnection");
            NinjectModule servicesModule = new ServicesModule();
            var kernel = new StandardKernel(DBModule,servicesModule);
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new  Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);
            
            
        }
    }
}
