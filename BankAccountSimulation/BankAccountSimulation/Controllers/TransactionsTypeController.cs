using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using ProjectRepository.Contracts;

namespace BankAccountSimulation.Controllers
{
    public class TransactionsTypeController : Controller
    {
        private readonly ITransactionsTypeRepository _iTransactionsTypeRepository;

        public TransactionsTypeController(ITransactionsTypeRepository iTransactionsTypeRepository)
        {
            _iTransactionsTypeRepository = iTransactionsTypeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iTransactionsTypeRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TransactionsType aTransactionsType)
        {
            if (ModelState.IsValid)
            {
                bool isAdd = _iTransactionsTypeRepository.Add(aTransactionsType);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Transactions Type save failed!";
            }

            return View(aTransactionsType);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            TransactionsType aTransactionsType = _iTransactionsTypeRepository.GetById(id);

            if (aTransactionsType == null)
                return NotFound();

            return View(aTransactionsType);
        }

        [HttpPost]
        public IActionResult Update(TransactionsType aTransactionsType)
        {
            if (ModelState.IsValid)
            {
                bool isUpdate = _iTransactionsTypeRepository.Update(aTransactionsType);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Transactions Type update failed!";
            }

            return View(aTransactionsType);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            TransactionsType aTransactionsType = _iTransactionsTypeRepository.GetById(id);

            if (aTransactionsType == null)
                return NotFound();

            return View(aTransactionsType);
        }

        [HttpPost]
        public IActionResult Remove(TransactionsType aTransactionsType)
        {
            bool isRemove = _iTransactionsTypeRepository.Remove(aTransactionsType);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Transactions Type remove failed!";
        }
    }
}