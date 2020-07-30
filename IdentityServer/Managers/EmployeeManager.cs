using IdentityServer.Data;
using IdentityServer.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace IdentityServer.Managers
{
    public class EmployeeManager : UserManager<Employee>
    {
        public EmployeeManager(IUserStore<Employee> store) : base(store) { }

        public static EmployeeManager Create(IdentityFactoryOptions<EmployeeManager> options,
                        IOwinContext context)
        {
            IdentityServerContext db = context.Get<IdentityServerContext>();
            EmployeeManager manager = new EmployeeManager(new UserStore<Employee>(db));

            return manager;
        }
    }
}