namespace IdentityServer.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityServer.Data.IdentityServerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentityServer.Data.IdentityServerContext context)
        {
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var adminRole = new IdentityRole { Name = "Admin" };
                var rickAstleyRole = new IdentityRole { Name = "SuperAdmin" };
                manager.Create(adminRole);
                manager.Create(rickAstleyRole);
            }

            context.SaveChanges();
        }
    }
}
