using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountSimulation.Controllers
{
    public class TransferMoneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}