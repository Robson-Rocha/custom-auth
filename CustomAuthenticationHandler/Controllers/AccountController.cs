using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuthenticationHandler.Controllers
{
    public class AccountController : Controller
    {
        //Step 14
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Step 16
        [HttpPost]
        public IActionResult Login(string returnUrl, string key)
        {
            if (returnUrl == null)
                returnUrl = "/";
            returnUrl += (returnUrl.Contains("?") ? "&" : "?") + "key=" + key;
            return Redirect(returnUrl);
        }

        //Step 19
        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}