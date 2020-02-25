using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BankAccountSimulation.Controllers
{
    public class AccountTypeController : Controller
    {
        private readonly IAccountTypeManager _iAccountTypeManager;

        public AccountTypeController(IAccountTypeManager iAccountTypeManager)
        {
            _iAccountTypeManager = iAccountTypeManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iAccountTypeManager.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountType aAccountType)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iAccountTypeManager.Add(aAccountType);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Account type has been save to failed!";
            }

            return View(aAccountType);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            AccountType aAccountType = _iAccountTypeManager.GetById(id);

            if (aAccountType == null)
                return NotFound();

            return View(aAccountType);
        }

        [HttpPost]
        public IActionResult Update(AccountType aAccountType)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iAccountTypeManager.Update(aAccountType);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Account type update failed!";
            }

            return View(aAccountType);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            AccountType aAccountType = _iAccountTypeManager.GetById(id);

            if (aAccountType == null)
                return NotFound();

            return View(aAccountType);
        }

        [HttpPost]
        public IActionResult Remove(AccountType aAccountType)
        {
            bool isRemove = _iAccountTypeManager.Remove(aAccountType);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Account type remove failed!";
        }
    }
}