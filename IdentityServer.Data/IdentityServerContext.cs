using IdentityServer.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IdentityServer.Data
{
    public class IdentityServerContext : IdentityDbContext<Employee>
    {
        public IdentityServerContext() : base("Data Source=ISERDYUK;;Initial Catalog=IdentityServer;Integrated Security=True") { }

        public IdentityServerContext(string constring) : base(constring)
        {

        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Cage> Cages { get; set; }
    }
}
