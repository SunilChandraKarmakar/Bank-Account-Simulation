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
    public class LoginCustomerController : Controller
    {
        private readonly ICustomerManager _iCustomerManager;
        private readonly IBranchManager _iBranchManager;
        private readonly IAccountManager _iAccountManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public LoginCustomerController(ICustomerManager iCustomerManager,
                                      IHostingEnvironment iHostingEnvironment, IBranchManager iBranchManager,
                                      IAccountManager iAccountManager)
        {
            _iCustomerManager = iCustomerManager;
            _iHostingEnvironment = iHostingEnvironment;
            _iBranchManager = iBranchManager;
            _iAccountManager = iAccountManager;
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

        private Customer LoginCustomer()
        {
            string customerId = HttpContext.Session.GetString("CustomerId");
            int convertCustomerId = Convert.ToInt32(customerId);
            Customer loginCustomerInfo = _iCustomerManager.ACustomerWithBranch(convertCustomerId);
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

                Customer aCustomer = _iCustomerManager.GetById(id);

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

                bool isUpdate = _iCustomerManager.Update(aCustomer);

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

        [HttpGet]
        public IActionResult LoginCustomerAccountInfo()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                Customer loginCustomerInfo = LoginCustomer();
                int loginCustomerId = loginCustomerInfo.Id;
                Account loginCustomerAccountInfo = _iAccountManager.GetLoginCustomerAccountByIncluding(loginCustomerId);
                return View(loginCustomerAccountInfo);
            }
            else
                return RedirectToAction("CustomerLogin", "LoginLogout");
        }
    }
}