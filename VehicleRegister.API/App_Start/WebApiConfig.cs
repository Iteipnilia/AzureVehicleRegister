using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleRegister.Repository.Interfaces;
using VehicleRegister.Repository.Repos;
using SimpleInjector.Integration.WebApi;

namespace VehicleRegister.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void RegisterSimpleInjector(HttpConfiguration config)
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IVehicleRepository, AzureSqlDataStorage>(Lifestyle.Scoped);
            container.Register<IVehicleServiceRepository, AzureSqlDataStorage>(Lifestyle.Scoped);


            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
