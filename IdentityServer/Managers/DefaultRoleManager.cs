using IdentityServer.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityServer.Managers
{
    public class DefaultRoleManager : RoleManager<IdentityRole>
    {
        public DefaultRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
        {
        }
    }


}