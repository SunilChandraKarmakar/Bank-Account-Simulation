﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BankAccountSimulation.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryManager _iCountryManager;

        public CountryController(ICountryManager iCountryManager)
        {
            _iCountryManager = iCountryManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_iCountryManager.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country aCountry)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iCountryManager.Add(aCountry);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Country save failed!";
            }

            return View(aCountry);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();

            Country aCountryDetails = _iCountryManager.GetById(id);

            if (aCountryDetails == null)
                return NotFound();

            return View(aCountryDetails);
        }

        [HttpPost]
        public IActionResult Update(Country aCountry)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iCountryManager.Update(aCountry);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Country update failed!";
            }

            return View(aCountry);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return NotFound();

            Country aCountryDetails = _iCountryManager.GetById(id);

            if (aCountryDetails == null)
                return NotFound();

            return View(aCountryDetails);
        }

        [HttpPost]
        public IActionResult Remove(Country aCountry)
        {
            bool isRemove = _iCountryManager.Remove(aCountry);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Counter remove failed!";
        }
    }
}