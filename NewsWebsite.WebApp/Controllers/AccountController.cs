using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebsite.WebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgotPassword([Required] string email)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("NotifySend", "Login");
        }

        [AllowAnonymous]
        public IActionResult NotifySend()
        {
            return View();
        }
    }
}
