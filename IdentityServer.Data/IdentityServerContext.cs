using IdentityServer.Data.Models;
using System.Data.Entity;

namespace IdentityServer.Data
{
    public class IdentityServerContext : DbContext
    {
        public IdentityServerContext(string constring) : base(constring)
        {

        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
