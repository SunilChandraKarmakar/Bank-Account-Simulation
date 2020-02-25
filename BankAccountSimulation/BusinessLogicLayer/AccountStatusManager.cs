using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class AccountStatusManager : BaseManager<AccountStatus>, IAccountStatusManager
    {
        private readonly IAccountStatusRepository _iAccountStatusRepository;

        public AccountStatusManager(IAccountStatusRepository iAccountStatusRepository)
                                    : base(iAccountStatusRepository)
        {
            _iAccountStatusRepository = iAccountStatusRepository;       
        }
    }
}
