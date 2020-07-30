using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer.Data
{
    public class DefaultRole : IdentityRole
    {
        public DefaultRole() : base() { }
        public DefaultRole(string name) : base(name) { }

        public int Floor { get; set; }
    }
}
