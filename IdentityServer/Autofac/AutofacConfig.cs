using Autofac;
using Autofac.Integration.Mvc;
using IdentityServer.Autofac;
using IdentityServer.Data;
using IdentityServer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<TestInjection>().As<ITestInjection>();
            builder.RegisterType<IdentityServerContext>().InstancePerRequest();
            builder.RegisterType<HouseManager>().As<IHouseManager>();
            builder.RegisterType<HouseRepository>().As<IHouseRepository>();

            builder.RegisterModule<AutofacModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}