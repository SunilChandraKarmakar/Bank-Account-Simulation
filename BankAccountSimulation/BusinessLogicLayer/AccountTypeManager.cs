using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class AccountTypeManager : BaseManager<AccountType>, IAccountTypeManager
    {
        private readonly IAccountTypeRepository _iAccountTypeRepository;

        public AccountTypeManager(IAccountTypeRepository iAccountTypeRepository) 
                                 : base(iAccountTypeRepository)
        {
            _iAccountTypeRepository = iAccountTypeRepository;
        }
    }
}
