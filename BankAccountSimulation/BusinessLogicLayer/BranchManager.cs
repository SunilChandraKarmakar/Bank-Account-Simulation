using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class BranchManager : BaseManager<Branch>, IBranchManager
    {
        private readonly IBranchRepository _iBranchRepository;

        public BranchManager(IBranchRepository iBranchRepository) : base(iBranchRepository)
        {
            _iBranchRepository = iBranchRepository;
        }

        public ICollection<Branch> GetBranchWithCountryAndCity()
        {
            return _iBranchRepository.GetBranchWithCountryAndCity();
        }

        public ICollection<City> GetCityByCountryId(int countryId)
        {
            return _iBranchRepository.GetCityByCountryId(countryId);
        }

        public Branch GetByIdWithCountryAndCity(int? id)
        {
            return _iBranchRepository.GetByIdWithCountryAndCity(id);
        }
    }
}
