using System;
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
    public class BranchController : Controller
    {
        private readonly IBranchManager _iBranchManager;
        private readonly ICountryManager _iCountryManager;
        private readonly ICityManager _iCityManager;

        public BranchController(IBranchManager iBranchManager, 
                                ICountryManager iCountryManager, ICityManager iCityManager)
        {
            _iBranchManager = iBranchManager;
            _iCountryManager = iCountryManager;
            _iCityManager = iCityManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
                return View(_iBranchManager.GetBranchWithCountryAndCity());
            else
                return RedirectToAction("Index", "Home");
        }

        private List<SelectListItem> CountryList()
        {
            List<SelectListItem> countryList = _iCountryManager.GetAll()
                                                .Select(c=> new SelectListItem 
                                                { 
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name,
                                                }).ToList();
            return countryList;
        }

        private List<SelectListItem> CityList()
        {
            List<SelectListItem> cityList = _iCityManager.GetAll()
                                                .Select(c => new SelectListItem
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name,
                                                }).ToList();
            return cityList;
        }

        [Route("api/[controller]/[action]")]
        public JsonResult GetCityByCountryId(int countryId)
        {
            ICollection<City> cityList = _iBranchManager.GetCityByCountryId(countryId);
            return Json(cityList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                ViewBag.CountryList = CountryList();
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(Branch aBranch)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iBranchManager.Add(aBranch);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Branch has been not save!";
            }

            ViewBag.CountryList = CountryList();
            return View(aBranch);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                if (id == null)
                    return NotFound();

                Branch aBranchDetails = _iBranchManager.GetById(id);

                if (aBranchDetails == null)
                    return NotFound();

                ViewBag.CountryList = CountryList();
                ViewBag.CityList = CityList();
                return View(aBranchDetails);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Update(Branch aBranch)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iBranchManager.Update(aBranch);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Branch failed to update!";
            }

            ViewBag.CountryList = CountryList();
            ViewBag.CityList = CityList();
            return View(aBranch);
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                if (id == null)
                    return NotFound();

                Branch aBranchDetails = _iBranchManager.GetById(id);

                if (aBranchDetails == null)
                    return NotFound();

                ViewBag.CountryList = CountryList();
                ViewBag.CityList = CityList();
                return View(aBranchDetails);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Remove(Branch aBranch)
        {
            bool isRemove = _iBranchManager.Remove(aBranch);

            if (isRemove)
                return RedirectToAction("Index");
            else
                return ViewBag.ErrorMessage = "Branch remove failed!";
        }
    }
}