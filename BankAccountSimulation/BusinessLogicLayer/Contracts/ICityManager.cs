using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Contracts
{
    public interface ICityManager : IBusinessLogicManager<City>
    {
        public ICollection<City> GetCityWithCountry();
    }
}
