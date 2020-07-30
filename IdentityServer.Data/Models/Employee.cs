using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer.Data.Models
{
    public class Employee : IdentityUser
    {
        public string Name { get; set; }
        public int Type { get; set; }
    }
}
