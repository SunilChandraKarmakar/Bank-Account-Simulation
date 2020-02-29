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
    public class AccountStatusController : Controller
    {
        private readonly IAccountStatusManager _iAccountStatusManager;

        public AccountStatusController(IAccountStatusManager iAccountStatusManager)
        {
            _iAccountStatusManager = iAccountStatusManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
                return View(_iAccountStatusManager.GetAll());
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Id") != null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(AccountStatus aAccountStatus)
        {
            if (ModelState.IsValid)
            {
                bool isAdd = _iAccountStatusManager.Add(aAccountStatus);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Account type has been save to failed!";
            }

            return View(aAccountStatus);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                if (id == null)
                    return NotFound();

                AccountStatus aAccountStatus = _iAccountStatusManager.GetById(id);

                if (aAccountStatus == null)
                    return NotFound();

                return View(aAccountStatus);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Update(AccountStatus aAccountStatus)
        {
            if (ModelState.IsValid)
            {
                bool isUpdate = _iAccountStatusManager.Update(aAccountStatus);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Account type update failed!";
            }

            return View(aAccountStatus);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                if (id == null)
                    return NotFound();

                AccountStatus aAccountStatus = _iAccountStatusManager.GetById(id);

                if (aAccountStatus == null)
                    return NotFound();

                return View(aAccountStatus);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Remove(AccountStatus aAccountStatus)
        {
            bool isRemove = _iAccountStatusManager.Remove(aAccountStatus);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Account type remove failed!";
        }
    }
}