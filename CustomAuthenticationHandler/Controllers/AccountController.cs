using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuthenticationHandler.Controllers
{
    public class AccountController : Controller
    {
        //Step 14 - Método de login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Step 16 - Processamento do login
        [HttpPost]
        public IActionResult Login(string returnUrl, string key)
        {
            if (returnUrl == null)
                returnUrl = "/";
            returnUrl += (returnUrl.Contains("?") ? "&" : "?") + "key=" + key;
            return Redirect(returnUrl);
        }

        //Step 19 - Página de acesso negado
        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}