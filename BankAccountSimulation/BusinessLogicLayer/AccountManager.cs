using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using Models.ViewModel;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class AccountManager : BaseManager<Account>, IAccountManager 
    {
        private readonly IAccountRepository _iAccountRepository;

        public AccountManager(IAccountRepository iAccountRepository) : base(iAccountRepository)
        {
            _iAccountRepository = iAccountRepository;
        }

        public override ICollection<Account> GetAll()
        {
            return _iAccountRepository.GetAll();
        }

        public List<CustomerNotInAccount> GetCustomerByBranchIdNotInAccount(int branchId)
        {
            return _iAccountRepository.GetCustomerByBranchIdNotInAccount(branchId);
        }

        public Account GetAccountByIncluding(int? id)
        {
            return _iAccountRepository.GetAccountByIncluding(id);
        }

        public Account GetLoginCustomerAccountByIncluding(int loginCustomerId)
        {
            return _iAccountRepository.GetLoginCustomerAccountByIncluding(loginCustomerId);
        }
    }
}
