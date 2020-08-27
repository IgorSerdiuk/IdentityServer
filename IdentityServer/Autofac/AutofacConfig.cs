using Autofac;
using Autofac.Integration.Mvc;
using IdentityServer.Autofac;
using IdentityServer.Data;
using IdentityServer.Data.Models;
using IdentityServer.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
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

            var ctx = new IdentityServerContext();
            builder.Register<IdentityServerContext>(x => ctx);
            builder.Register<UserStore<Employee>>(x => new UserStore<Employee>(ctx)).AsImplementedInterfaces();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();
            builder.Register<IdentityFactoryOptions<DefaultRoleManager>>(c => new IdentityFactoryOptions<DefaultRoleManager>());
            builder.RegisterType<DefaultRoleManager>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}