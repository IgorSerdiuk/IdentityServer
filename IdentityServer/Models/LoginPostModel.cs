using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityServer.Models
{
    public class LoginPostModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}