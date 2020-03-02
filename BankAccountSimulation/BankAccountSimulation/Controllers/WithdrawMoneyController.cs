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
    public class WithdrawMoneyController : Controller
    {
        private readonly IWithdrawMoneyManager _iWithdrawMoneyManager;
        private readonly ICustomerManager _iCustomerManager;
        private readonly IAccountManager _iAccountManager;

        public WithdrawMoneyController(IWithdrawMoneyManager iWithdrawMoneyManager, 
                                        ICustomerManager iCustomerManager, IAccountManager iAccountManager)
        {
            _iWithdrawMoneyManager = iWithdrawMoneyManager;
            _iCustomerManager = iCustomerManager;
            _iAccountManager = iAccountManager;
        }

        private Customer LoginCustomer()
        {
            string customerId = HttpContext.Session.GetString("CustomerId");
            int convertCustomerId = Convert.ToInt32(customerId);
            Customer loginCustomerInfo = _iCustomerManager.ACustomerWithBranch(convertCustomerId);
            return loginCustomerInfo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iWithdrawMoneyManager.GetAll());
            else
                return RedirectToAction("AdminLogin", "LoginLogout");
        }

        [HttpGet]
        public IActionResult LoginCustomerIndex()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                string customerId = HttpContext.Session.GetString("CustomerId");
                int convertCustomerId = Convert.ToInt32(customerId);       
                Account getAccountMatchByCustomerId = _iAccountManager
                                                      .GetLoginCustomerAccountByIncluding(convertCustomerId);
                string accoundId = getAccountMatchByCustomerId.AccountNumber;
                int convertAccountId = Convert.ToInt32(accoundId);
                ICollection<WithdrawMoney> withdrawMoneyList = _iWithdrawMoneyManager.GetAll();
                List<WithdrawMoney> metchAccountWithdrawMoney = withdrawMoneyList
                                                                .Where(w => w.AccountId == convertAccountId)
                                                                .ToList();
                return View(metchAccountWithdrawMoney);
            }
            else
                return RedirectToAction("CustomerLogin", "LoginLogout");
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetAccountNumber()
        {
            Customer loginCustomer = LoginCustomer();
            int loginCustomerId = loginCustomer.Id;
            Account loginCuatomerAccount = _iAccountManager.GetLoginCustomerAccountByIncluding(loginCustomerId);
            string loginCustomerAccountNumber = loginCuatomerAccount.AccountNumber;
            return Json(loginCustomerAccountNumber);
        }

        [Route("api/[controller]/[action]")]
        public JsonResult CheckAmmount(float ammount)
        {
            Customer loginCustomer = LoginCustomer();
            int loginCustomerId = loginCustomer.Id;
            Account loginCuatomerAccount = _iAccountManager.GetLoginCustomerAccountByIncluding(loginCustomerId);
            float loginCustomerBalence = loginCuatomerAccount.Balance;

            if (loginCustomerBalence < ammount)
                return Json(1);

            if (ammount <= 0)
                return Json(2);
            else
                return Json(0);
        }

        [HttpGet]
        public IActionResult WithdrawMoney()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
                return View();
            else
                return RedirectToAction("CustomerLogin", "LoginLogout");
        }

        [HttpPost]
        public IActionResult WithdrawMoney(WithdrawMoney withdrawMoneyDetails)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                withdrawMoneyDetails.WithdrawDate = DateTime.Now;
                Account loginCustomerAccount = new Account();

                if (ModelState.IsValid)
                {
                    Customer loginCustomer = LoginCustomer();
                    int loginCustomerId = loginCustomer.Id;
                    loginCustomerAccount = _iAccountManager.GetLoginCustomerAccountByIncluding(loginCustomerId);
                    float totalAmmount = loginCustomerAccount.Balance - withdrawMoneyDetails.Ammount;
                    loginCustomerAccount.Balance = totalAmmount;

                    bool isUpdateForLoginCustomer = _iAccountManager.Update(loginCustomerAccount);
                    
                    if (isUpdateForLoginCustomer != true)
                        return ViewBag.ErrorMessage = "Login customer account failed to update!";

                    bool isAdd = _iWithdrawMoneyManager.Add(withdrawMoneyDetails);

                    if (isAdd)
                        return RedirectToAction("Index", "WithdrawMoney");
                    else
                        return ViewBag.ErrorMessage = "Withdraw money is failed!";
                }
                else
                    return View(withdrawMoneyDetails);
            }
            else
                return RedirectToAction("CustomerLogin", "LoginLogout");
        }
    }
}