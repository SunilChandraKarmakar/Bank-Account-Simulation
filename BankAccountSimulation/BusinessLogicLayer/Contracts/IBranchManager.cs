using BusinessLogicLayer.BaseBLL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Contracts
{
    public interface IBranchManager : IBusinessLogicManager<Branch>
    {
        public ICollection<Branch> GetBranchWithCountryAndCity();
        public ICollection<City> GetCityByCountryId(int countryId);
        public Branch GetByIdWithCountryAndCity(int? id);
    }
}
