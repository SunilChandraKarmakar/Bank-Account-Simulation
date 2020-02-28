using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BankAccountSimulation.Controllers
{
    public class LoginLogoutController : Controller
    {
        private readonly IAdminManager _iAdminManager;

        public LoginLogoutController(IAdminManager iAdminManager)
        {
            _iAdminManager = iAdminManager;
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string email, string password)
        {
            Admin loginAdminDetails = new Admin();

            if (ModelState.IsValid)
            {                               
                loginAdminDetails = _iAdminManager.MatchAdmin(email, password);

                if (loginAdminDetails != null)
                {
                    HttpContext.Session.SetString("Id", loginAdminDetails.Id.ToString());
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.ErrorMessage = "Login failed! Please try again.";
            }

            return View(loginAdminDetails);
        }

        [HttpGet]
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CustomerLogin()
        {
            return View();
        }
    }
}