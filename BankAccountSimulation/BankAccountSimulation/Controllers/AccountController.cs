using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace BankAccountSimulation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _iAcccountManager;
        private readonly IBranchManager _iBranchManager;
        private readonly IAccountTypeManager _iAccountTypeManager;
        private readonly IAccountStatusManager _iAccountStatusManager;
        private readonly ICustomerManager _iCustomerManager;

        public AccountController(IAccountManager iAcccountManager, 
                                IBranchManager iBranchManager,
                                IAccountTypeManager iAccountTypeManager,
                                IAccountStatusManager iAccountStatusManager, ICustomerManager iCustomerManager)
        {
            _iAcccountManager = iAcccountManager;
            _iBranchManager = iBranchManager;
            _iAccountTypeManager = iAccountTypeManager;
            _iAccountStatusManager = iAccountStatusManager;
            _iCustomerManager = iCustomerManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iAcccountManager.GetAll());
        }

        private List<SelectListItem> BranchList()
        {
            List<SelectListItem> branchList = _iBranchManager.GetAll()
                                              .Select(b => new SelectListItem 
                                              {
                                                    Value = b.Id.ToString(),
                                                    Text = b.Name
                                              }).ToList();
            return branchList;
        }

        private List<SelectListItem> AccountTypeList()
        {
            List<SelectListItem> accountTypeList = _iAccountTypeManager.GetAll()
                                                    .Select(act=> new SelectListItem 
                                                    {
                                                        Value = act.Id.ToString(),
                                                        Text = act.Name
                                                    }).ToList();
            return accountTypeList;
        }

        public List<SelectListItem> AccountStatusList()
        {
            List<SelectListItem> accountStatusList = _iAccountStatusManager.GetAll()
                                                     .Select(ast => new SelectListItem 
                                                     { 
                                                        Value = ast.Id.ToString(),
                                                        Text = ast.Name
                                                     }).ToList();
            return accountStatusList;
        }

        public List<SelectListItem> CustomerList()
        {
            List<SelectListItem> customerList = _iCustomerManager.GetAll()
                                                     .Select(ast => new SelectListItem
                                                     {
                                                         Value = ast.Id.ToString(),
                                                         Text = ast.Name
                                                     }).ToList();
            return customerList;
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetCustomerByBranchId(int branchId)
        {
            ICollection<Customer> customers = _iAcccountManager.GetCustomerByBranchId(branchId);
            return Json(customers);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GenerateAccountNumber()
        {
            int startCount = 1001;
            string year = DateTime.Now.Year.ToString();
            string generatedAccountNumber = "";

            ICollection<Account> accounts = _iAcccountManager.GetAll();

            if (accounts.Count == 0)
                generatedAccountNumber = startCount + year;
            else
            {
                Account accountLastIndex = _iAcccountManager.GetAll().LastOrDefault();
                string lastAccountNumber = accountLastIndex.AccountNumber;
                string subStringLastAccountNumber = lastAccountNumber.Substring(0, 4);
                generatedAccountNumber = (subStringLastAccountNumber + 1) + year;
            }

            return Json(generatedAccountNumber);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.BranchList = BranchList();
            ViewBag.AccountTypeList = AccountTypeList();
            ViewBag.AccountStatusList = AccountStatusList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account aAccount)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iAcccountManager.Add(aAccount);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Account create has been failed!";
            }

            ViewBag.BranchList = BranchList();
            ViewBag.AccountTypeList = AccountTypeList();
            ViewBag.AccountStatusList = AccountStatusList();
            return View(aAccount);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            Account aAccountDetails = _iAcccountManager.GetById(id);

            if (aAccountDetails == null)
                return NotFound();

            ViewBag.BranchList = BranchList();
            ViewBag.AccountTypeList = AccountTypeList();
            ViewBag.AccountStatusList = AccountStatusList();
            ViewBag.CustomerList = CustomerList();
            return View(aAccountDetails);
        }

        [HttpPost]
        public IActionResult Update(Account aAccount)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iAcccountManager.Update(aAccount);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Account update has been failed!";
            }

            ViewBag.BranchList = BranchList();
            ViewBag.AccountTypeList = AccountTypeList();
            ViewBag.AccountStatusList = AccountStatusList();
            ViewBag.CustomerList = CustomerList();
            return View(aAccount);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            Account aAccountInfo = _iAcccountManager.GetAccountByIncluding(id);

            if (aAccountInfo == null)
                return NotFound();

            return View(aAccountInfo);
        }

        [HttpPost]
        public IActionResult Remove(Account aAccount)
        {
            bool isRemove = _iAcccountManager.Remove(aAccount);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Account failed to remove!";
        }
    }
}