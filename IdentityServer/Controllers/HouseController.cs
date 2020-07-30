using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace IdentityServer.Controllers
{
    public class HouseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = JsonConvert.SerializeObject(new { Name = "IGOR", LastName = "Serdiuk" });
            return Json(result);
        }
    }
}
