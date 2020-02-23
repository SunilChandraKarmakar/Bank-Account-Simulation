using Microsoft.EntityFrameworkCore;
using Models;
using ProjectRepository.BaseRpository;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRepository
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public ICollection<Branch> GetBranchWithCountryAndCity()
        {
            ICollection<Branch> branchList = ourContext.Branches
                                             .Include(b => b.Country)
                                             .Include(b => b.City).ToList();
            return branchList;
        }

        public ICollection<City> GetCityByCountryId(int countryId)
        {
            List<City> cityList = ourContext.Cities.Where(c => c.CountryId == countryId).ToList();
            return cityList;
        }

        public Branch GetByIdWithCountryAndCity(int? id)
        {
            Branch aBranchWithCountryAndCity = ourContext.Branches
                                               .Include(b => b.Country)
                                               .Include(b => b.City)
                                               .Where(b => b.Id == id).FirstOrDefault();
            return aBranchWithCountryAndCity;
        }
    }
}
