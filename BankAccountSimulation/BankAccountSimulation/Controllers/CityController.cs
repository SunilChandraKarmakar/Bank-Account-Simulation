﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace BankAccountSimulation.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityManager _iCityManager;
        private readonly ICountryManager _iCountryManager;

        public CityController(ICityManager iCityManager, ICountryManager iCountryManager)
        {
            _iCityManager = iCityManager;
            _iCountryManager = iCountryManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View(_iCityManager.GetCityWithCountry());
            else
                return RedirectToAction("Index", "Home");
        }

        private List<SelectListItem> GetAllCountry()
        {
            List<SelectListItem> countryList = _iCountryManager.GetAll()
                                               .Select(c=> new SelectListItem 
                                               { 
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name 
                                               }).ToList();
            return countryList;
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.CountryList = GetAllCountry();
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(City aCity)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iCityManager.Add(aCity);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "City save failed!";
            }

            ViewBag.CountryList = GetAllCountry();
            return View(aCity);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                City aCityDetails = _iCityManager.GetById(id);

                if (aCityDetails == null)
                    return NotFound();

                ViewBag.CountryList = GetAllCountry();
                return View(aCityDetails);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Update(City aCity)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iCityManager.Update(aCity);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "City has been update failed!";
            }

            ViewBag.CountryList = GetAllCountry();
            return View(aCity);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                City aCityDetails = _iCityManager.GetById(id);

                if (aCityDetails == null)
                    return NotFound();

                ViewBag.CountryList = GetAllCountry();
                return View(aCityDetails);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Remove(City aCity)
        {
            bool isRemove = _iCityManager.Remove(aCity);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "City remove failed!";
        }
    }
}