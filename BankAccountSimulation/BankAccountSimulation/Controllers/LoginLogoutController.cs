using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using ProjectRepository.Contracts;

namespace BankAccountSimulation.Controllers
{
    public class LoginLogoutController : Controller
    {
        private readonly IAdminManager _iAdminManager;
        private readonly ICustomerManager _iCustomerManager;

        public LoginLogoutController(IAdminManager iAdminManager, ICustomerManager iCustomerManager)
        {
            _iAdminManager = iAdminManager;
            _iCustomerManager = iCustomerManager;
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
                    HttpContext.Session.SetString("AdminId", loginAdminDetails.Id.ToString());
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.ErrorMessage = "Do not match email or password! Please try again.";
            }

            return View(loginAdminDetails);
        }

        [HttpGet]
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin", "LoginLogout");
        }

        [HttpGet]
        public IActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerLogin(string email, string password)
        {
            Customer loginCustomerDetails = new Customer();
            
            if(ModelState.IsValid)
            {
                loginCustomerDetails = _iCustomerManager.MatchCustomer(email, password);

                if (loginCustomerDetails != null)
                {
                    HttpContext.Session.SetString("CustomerId", loginCustomerDetails.Id.ToString());
                    return RedirectToAction("LoginCustomerInfo", "LoginCustomer");
                }
                else
                    ViewBag.ErrorMessage = "Do not match email or password! Please try again.";
            }

            return View(loginCustomerDetails);
        }

        [HttpGet]
        public IActionResult CustomerLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("CustomerLogin", "LoginLogout");
        }
    }
}