using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRepository.Contracts
{
    public interface IBranchRepository : IRepository<Branch>
    {
        public ICollection<Branch> GetBranchWithCountryAndCity();  
        public ICollection<City> GetCityByCountryId(int countryId);
        public Branch GetByIdWithCountryAndCity(int? id);
    }
}
