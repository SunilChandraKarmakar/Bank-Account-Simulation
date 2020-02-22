using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class AdminManager : BaseManager<Admin>, IAdminManager
    {
        private readonly IAdminRepository _iAdminRepository; 
        
        public AdminManager(IAdminRepository iAdminRepository) : base(iAdminRepository)
        {
            _iAdminRepository = iAdminRepository;
        }
    }
}
