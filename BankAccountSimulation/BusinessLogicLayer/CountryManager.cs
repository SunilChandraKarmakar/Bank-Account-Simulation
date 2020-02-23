using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class CountryManager : BaseManager<Country>, ICountryManager 
    {
        private readonly ICountryRepository _iCountryRepository;
        
        public CountryManager(ICountryRepository iCountryRepository) : base(iCountryRepository)
        {
            _iCountryRepository = iCountryRepository;
        }
    }
}
