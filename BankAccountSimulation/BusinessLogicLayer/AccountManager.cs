using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
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

        public ICollection<Customer> GetCustomerByBranchId(int branchId)
        {
            return _iAccountRepository.GetCustomerByBranchId(branchId);
        }

        public Account GetAccountByIncluding(int? id)
        {
            return _iAccountRepository.GetAccountByIncluding(id);
        }
    }
}
