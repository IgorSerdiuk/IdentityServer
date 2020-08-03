using IdentityServer.Data.Models;
using IdentityServer.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestInjection _test;

        public HomeController(ITestInjection testInjection)
        {
            _test = testInjection;
        }

        public async Task<ActionResult>Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<EmployeeManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            //byte[] bytes = Encoding.ASCII.GetBytes("12345");
            //var passwordHash = Convert.ToBase64String(bytes);

            var auth = User.Identity.IsAuthenticated;
            //var createdUser = await userManager.CreateAsync(new Employee
            //{
            //    Name = "IGOSitto",
            //    Email = "IGOSitto@gmail.com",
            //    UserName = "IGOSitto",
            //}, "123456789");

            Employee user = userManager.Find("IGOSitto", "123456789");
            if (user != null)
            {
                var ident = userManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                ident.AddClaim(new Claim("claiim", "SomeValue"));
                //use the instance that has been created. 
                authManager.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, ident);
                return View();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}