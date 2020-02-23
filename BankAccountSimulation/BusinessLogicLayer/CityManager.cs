using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class CityManager : BaseManager<City>, ICityManager 
    {
        private readonly ICityRepository _iCityRepository;

        public CityManager(ICityRepository iCityRepository) : base(iCityRepository)
        {
            _iCityRepository = iCityRepository;
        }

        public ICollection<City> GetCityWithCountry()
        {
            return _iCityRepository.GetCityWithCountry();
        }
    }
}
