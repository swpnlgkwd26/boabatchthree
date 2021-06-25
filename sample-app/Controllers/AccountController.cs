using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Controllers
{
    // Authentication and Authorization
    [Route("authorize")]
    public class AccountController : Controller
    {
        [Route("login/{userName:minlength(4)}/{password:minlength(4)}")]
        public IActionResult Login(string userName, string password)
        {
            return Content("Login Page");
        }
        [Route("logout")]
        public IActionResult Logout()
        {
            return Content("Logout Page");
        }
        [Route("register")]
        public IActionResult Register()
        {
            return Content("Register Page");
        }
    }
}
