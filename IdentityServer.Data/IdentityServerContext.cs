using IdentityServer.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace IdentityServer.Data
{
    public class IdentityServerContext : IdentityDbContext<Employee>, IIdentityServerContext
    {
        public IdentityServerContext() : base("DefaultConnection") { }

        public IdentityServerContext(string constring) : base(constring)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Cage> Cages { get; set; }
    }

    public interface IIdentityServerContext : IDisposable
    {
        DbSet<Animal> Animals { get; }
        DbSet<Cage> Cages { get; }
    }
}
