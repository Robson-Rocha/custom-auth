using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomAuthenticationHandler.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CustomAuthenticationHandler.Auth;

namespace CustomAuthenticationHandler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Step 12
        [Authorize]
        //Step 17
        //[Authorize(Roles = "Admin")] 
        //Step 21
        //[Authorize(AuthenticationSchemes = MyCustomAuthSchemes.AdminScheme)] 
        public IActionResult About()
        {
            string userName = User.Identity.Name; // User.FindFirst(ClaimTypes.Name).Value;
            string userEmail = User.FindFirst(ClaimTypes.Email).Value;
            ViewData["Message"] =  $"Welcome {userName} <{userEmail}>!";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
