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
    public class CityRepository : BaseRepository<City>, ICityRepository 
    {
        public ICollection<City> GetCityWithCountry()
        {
            List<City> cityWithCountry = ourContext.Cities
                                        .Include(c => c.Country).ToList();
            return cityWithCountry;
        }
    }
}
