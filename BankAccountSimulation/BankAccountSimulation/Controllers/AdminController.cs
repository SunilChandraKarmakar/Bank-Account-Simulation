using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BankAccountSimulation.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminManager _iAdminManager;

        public AdminController(IAdminManager iAdminManager)
        {
            _iAdminManager = iAdminManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Admin> adminList = _iAdminManager.GetAll();
            return View(adminList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Admin aAdmin)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iAdminManager.Add(aAdmin);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Admin create failed!";
            }

            return View(aAdmin);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            Admin aAdminDetails = _iAdminManager.GetById(id);

            if (aAdminDetails == null)
                return NotFound();

            return View(aAdminDetails);
        }

        [HttpPost]
        public IActionResult Update(Admin aAdmin)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iAdminManager.Update(aAdmin);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Admin update failed!";
            }

            return View(aAdmin);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            Admin aAdminDetails = _iAdminManager.GetById(id);

            if (aAdminDetails == null)
                return NotFound();

            return View(aAdminDetails);
        }

        [HttpPost]
        public IActionResult Remove(Admin aAdmin)
        {
            bool isRemove = _iAdminManager.Remove(aAdmin);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Admin delete failed!";
        }
    }
}