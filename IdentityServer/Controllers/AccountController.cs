using IdentityServer.Data.Models;
using IdentityServer.Managers;
using IdentityServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(LoginPostModel model)
        {
            var ctx = HttpContext.GetOwinContext();

            var userManager = ctx.GetUserManager<EmployeeManager>();
            var auth = ctx.Authentication;
            var user = await userManager.FindAsync(model.UserName, model.Password);

            var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            auth.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
            {
                IsPersistent = false,
            }, identity);

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterPostModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<EmployeeManager>();
            var employee = new Employee
            {
                Email = model.Email,
                Name = model.UserName,
                Type = model.Type,
                UserName = model.UserName
            };

            await userManager.CreateAsync(employee, model.Password);

            //var roleManager = HttpContext.GetOwinContext().Get<RoleManager<IdentityRole>>();
            //await roleManager.CreateAsync(new IdentityRole
            //{
            //    Name = "Admin"
            //});
            //var createdUser = await userManager.FindAsync(model.UserName, model.Password);
            //await userManager.AddToRoleAsync(createdUser.Id, "Admin");

            return RedirectToAction("LogIn");
        }


    }
}