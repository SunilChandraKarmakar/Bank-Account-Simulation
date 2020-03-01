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
    public class TransferMoneyController : Controller
    {
        private readonly ITransferMoneyManager _iTransferMoneyManager;
        private readonly ICustomerManager _iCustomerManager;
        private readonly IAccountManager _iAccountManager;

        public TransferMoneyController(ITransferMoneyManager iTransferMoneyManager,
                                       ICustomerManager iCustomerManager, IAccountManager iAccountManager)
        {
            _iTransferMoneyManager = iTransferMoneyManager;
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
        public IActionResult TransferMoneyRecord()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
                return View(_iTransferMoneyManager.GetAll());
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
        public JsonResult CheckAccountNumber(string sendingAccountNumber)
        {
            Account checkAccountNumber = _iAccountManager.CheckAccountNumber(sendingAccountNumber);

            if (checkAccountNumber != null)
                return Json(1);
            else
                return Json(0);
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
        public IActionResult TransferMoney()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
                return View();
            else
                return RedirectToAction("CustomerLogin", "LoginLogout");
        }

        [HttpPost]
        public IActionResult TransferMoney(TransferMoney detailsTransferMoney)
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                detailsTransferMoney.TransferMoneyDate = DateTime.Now;
                Account loginCustomerAccount = new Account();

                if (ModelState.IsValid)
                {
                    Customer loginCustomer = LoginCustomer();
                    int loginCustomerId = loginCustomer.Id;
                    loginCustomerAccount = _iAccountManager.GetLoginCustomerAccountByIncluding(loginCustomerId);
                    float totalAmmount = loginCustomerAccount.Balance - detailsTransferMoney.Ammount;
                    loginCustomerAccount.Balance = totalAmmount;

                    Account findAccountForAddBalance = _iAccountManager.FindAccountByAccountNumber(detailsTransferMoney.SendAccountNumber);
                    float addAmmount = findAccountForAddBalance.Balance + detailsTransferMoney.Ammount;
                    findAccountForAddBalance.Balance = addAmmount;

                    bool isUpdateForLoginCustomer = _iAccountManager.Update(loginCustomerAccount);
                    bool isUpdateForAccountAddBalance = _iAccountManager.Update(findAccountForAddBalance);

                    if (isUpdateForLoginCustomer != true)
                        return ViewBag.ErrorMessage = "Login customer account failed to update!";

                    if (isUpdateForAccountAddBalance != true)
                        return ViewBag.ErrorMessage = "Add Balance failed to update!";

                    bool isAdd = _iTransferMoneyManager.Add(detailsTransferMoney);

                    if (isAdd)
                        return RedirectToAction("TransferMoneyRecord", "TransferMoney");
                    else
                        return ViewBag.ErrorMessage = "Send money is failed!";
                }
                return View(detailsTransferMoney);
            }
            else
                return RedirectToAction("CustomerLogin", "LoginLogout");
        }
    }
}