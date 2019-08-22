using Autofac;
using Autofac.Integration.Mvc;
using NetDemo.Interfaces.Contract;
using NetDemo.Repositories;
using NetDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NetDemo.Interfaces;

namespace NetDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterSource(new ViewRegistrationSource());

            // manual registration of types;                        
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<TrainingRepository>().As<ITrainingRepository>();
            builder.RegisterType<DemoContext>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }
    }
}
