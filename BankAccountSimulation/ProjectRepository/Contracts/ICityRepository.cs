using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRepository.Contracts
{
    public interface ICityRepository : IRepository<City>
    {
        public ICollection<City> GetCityWithCountry();
    }
}
