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
        private readonly DefaultRoleManager _roleManager;

        public HomeController(ITestInjection testInjection, DefaultRoleManager roleManager)
       
        {
            _test = testInjection;
            _roleManager = roleManager;
        }

        public async Task<ActionResult> Index()
        {
            //_roleManager = HttpContext.GetOwinContext().Get<RoleManager<IdentityRole>>();
            var userManager = HttpContext.GetOwinContext().GetUserManager<EmployeeManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            //byte[] bytes = Encoding.ASCII.GetBytes("12345");
            //var passwordHash = Convert.ToBase64String(bytes);

            var auth = User.Identity.IsAuthenticated;
            var createdUser = await userManager.CreateAsync(new Employee
            {
                Name = "IGOSitto",
                Email = "IGOSitto@gmail.com",
                UserName = "IGOSitto",
            }, "123456789");

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

        public async Task<ActionResult> About()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<EmployeeManager>();
            //Поиск Роли по названию
            var role = await _roleManager.FindByNameAsync("Admin");

            if (role == null)
            {
                //Создание новой роли
                var result = _roleManager.Create(new IdentityRole("Admin"));
            }

            var  user = userManager.Find("IGOSitto", "123456789");
            //добавление Новой Роли пользователю
            userManager.AddToRole(user.Id, "Admin");

            //Проверка, есть ли роль у пользователя
            var isInRole = userManager.IsInRole(user.Id, "Admin");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}