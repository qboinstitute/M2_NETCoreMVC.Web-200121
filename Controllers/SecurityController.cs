using M2_NETCoreMVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M2_NETCoreMVC.Web.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Login(string email, string password)
        //public IActionResult Login(Usuario usuario)
        public IActionResult Login(IFormCollection form)
        {
            string email = form["email"];//usuario.email;
            string password = form["password"];//usuario.password;

            if (email.Equals("luis@qbo.com") && password.Equals("123456"))
            {
                return RedirectToAction("Index", "Home", new { area = "Marketing" });
            }

            return RedirectToAction("Index");//View("Index");
        }


    }
}
