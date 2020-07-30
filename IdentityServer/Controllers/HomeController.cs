using IdentityServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ctx = new IdentityServerContext("Data Source=ISERDYUK;;Initial Catalog=IdentityServer;Integrated Security=True");

            var employees = ctx.Employees.AsNoTracking().ToList();

            return View(employees);
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