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
            if (HttpContext.Session.GetString("Id") != null)
            {
                ICollection<Admin> adminList = _iAdminManager.GetAll();
                return View(adminList);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
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
            if (HttpContext.Session.GetString("Id") != null)
            {
                if (id == null)
                    return NotFound();

                Admin aAdminDetails = _iAdminManager.GetById(id);

                if (aAdminDetails == null)
                    return NotFound();

                return View(aAdminDetails);
            }
            else
                return RedirectToAction("Index", "Home");                 
        }

        [HttpPost]
        public IActionResult Update(Admin aAdmin)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                if (ModelState.IsValid)
                {
                    bool isUpdate = _iAdminManager.Update(aAdmin);

                    if (isUpdate)
                        return RedirectToAction("Index");
                    else
                        return ViewBag.ErrorMessage = "Admin update failed!";
                }

                return View(aAdmin);
            }
            else
                return RedirectToAction("Index", "Home");              
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                if (id == null)
                    return NotFound();

                Admin aAdminDetails = _iAdminManager.GetById(id);

                if (aAdminDetails == null)
                    return NotFound();

                return View(aAdminDetails);
            }
            else
                return RedirectToAction("Index", "Home");                  
        }

        [HttpPost]
        public IActionResult Remove(Admin aAdmin)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                bool isRemove = _iAdminManager.Remove(aAdmin);

                if (isRemove)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Admin delete failed!";
            }
            else
                return RedirectToAction("Index", "Home");                           
        }
    }
}