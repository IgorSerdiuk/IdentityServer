using AutoMapper;
using IdentityServer.Data.Models;
using IdentityServer.Managers;
using IdentityServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class HouseController : Controller
    {
        private readonly IHouseManager _houseManager;
        private readonly IMapper _mapper;
        public HouseController(IHouseManager houseManager, IMapper mapper)
        {
            _houseManager = houseManager;
            _mapper = mapper;
        }


        public ActionResult Get()
        {
            var all = _houseManager.GetAll();
            var cookies = HttpContext.Request.Cookies["name"]?.Value;

            var cage = new Cage { Capacity = 3, Id = 1, Name = "IGOR" };

            var cageModel = _mapper.Map<CageModel>(cage);

            if (string.IsNullOrWhiteSpace(cookies))
            {
                var cookie = new System.Web.HttpCookie("name", "value");
                cookie.HttpOnly = true;
                cookie.Expires = DateTime.Now.AddDays(2);
                HttpContext.Response.Cookies.Add(cookie);
            }

            var user = HttpContext.User.Identity as ClaimsIdentity;
            if (user != null)
            {
                var claiim = user.Claims.FirstOrDefault(x => x.Type == "claiim");
            }

            var result = JsonConvert.SerializeObject(new { Name = "IGOR", LastName = "Serdiuk" });
            return View();
        }
    }
}
