using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace BankAccountSimulation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerManager _iCustomerMamager;
        private readonly IBranchManager _iBranchManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public CustomerController(ICustomerManager iCustomerManager, 
                                  IBranchManager iBranchManager, 
                                  IHostingEnvironment iHostingEnvironment)
        {
            _iCustomerMamager = iCustomerManager;
            _iBranchManager = iBranchManager;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iCustomerMamager.GetCustomerWithBranch());
            else
                return RedirectToAction("Index", "Home");
        }

        private List<SelectListItem> BranchList()
        {
            List<SelectListItem> branchList = _iBranchManager.GetAll()
                                            .Select(c => new SelectListItem 
                                            { 
                                                Value = c.Id.ToString(),
                                                Text = c.Name
                                            }).ToList();
            return branchList;
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.BranchList = BranchList();
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(Customer aCustomer, IFormFile picture)
        {
            if(ModelState.IsValid)
            {
                if(picture != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/CustomerPictures",
                                                  Path.GetFileName(picture.FileName)); 
                    picture.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aCustomer.Picture = "CustomerPictures/" + picture.FileName;
                }

                if (picture == null)
                    aCustomer.Picture = "CustomerPictures/NoImageFound.png";

                bool isAdd = _iCustomerMamager.Add(aCustomer);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Customer save has been failed!";
            }

            return View(aCustomer);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Customer aCustomer = _iCustomerMamager.GetById(id);

                if (aCustomer == null)
                    return NotFound();

                ViewBag.BranchList = BranchList();
                return View(aCustomer);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(Customer aCustomer, IFormFile picture)
        {
            if(ModelState.IsValid)
            {
                if (picture != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/CustomerPictures",
                                                  Path.GetFileName(picture.FileName));
                    picture.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aCustomer.Picture = "CustomerPictures/" + picture.FileName;
                }

                if (picture == null)
                    aCustomer.Picture = "CustomerPictures/NoImageFound.png";

                bool isUpdate = _iCustomerMamager.Update(aCustomer);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Customer failed to update!";
            }

            ViewBag.BranchList = BranchList();
            return View(aCustomer);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Customer aCustomer = _iCustomerMamager.ACustomerWithBranch(id);

                if (aCustomer == null)
                    return NotFound();

                return View(aCustomer);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Remove(Customer aCustomer)
        {
            bool isRemove = _iCustomerMamager.Remove(aCustomer);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Customer remove failed!";
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckExistEmail(string customerEmail)
        {
            string existEmail = _iCustomerMamager.ExistEmail(customerEmail);

            if (existEmail != null)
                return Json(1);
            else
                return Json(0);
        }

        private Customer LoginCustomer()
        {
            string customerId = HttpContext.Session.GetString("CustomerId");
            int convertCustomerId = Convert.ToInt32(customerId);
            Customer loginCustomerInfo = _iCustomerMamager.ACustomerWithBranch(convertCustomerId);
            return loginCustomerInfo;
        }

        [HttpGet]
        public IActionResult LoginCustomerInfo()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                Customer loginCustomerInfo = LoginCustomer();
                return View(loginCustomerInfo);
            }
            else
                return RedirectToAction("CustomerLogin", "LoginLogout");
        }

        [HttpGet]
        public IActionResult LoginCustomerUpdate(int? id)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                Customer aCustomer = _iCustomerMamager.GetById(id);

                if (aCustomer == null)
                    return NotFound();

                ViewBag.BranchList = BranchList();
                return View(aCustomer);
            }
            else
                return RedirectToAction("CustomerLogin", "LoginLogout");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult LoginCustomerUpdate(Customer aCustomer, IFormFile picture, string pic)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                  + "/CustomerPictures",
                                                  Path.GetFileName(picture.FileName));
                    picture.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aCustomer.Picture = "CustomerPictures/" + picture.FileName;
                }

                if (picture == null)
                    aCustomer.Picture = pic;

                bool isUpdate = _iCustomerMamager.Update(aCustomer);

                if (isUpdate)
                    return RedirectToAction("LoginCustomerInfo");
                else
                    return ViewBag.ErrorMessage = "Customer failed to update!";
            }
            else
            {
                ViewBag.BranchList = BranchList();
                return View(aCustomer);
            }
        }
    }
}