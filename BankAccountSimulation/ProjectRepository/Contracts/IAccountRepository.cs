﻿using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository.Contracts
{
    public interface IAccountRepository : IRepository<Account>
    {
        public List<CustomerNotInAccount> GetCustomerByBranchIdNotInAccount(int branchId);
        public Account GetAccountByIncluding(int? id);
        public Account GetLoginCustomerAccountByIncluding(int loginCustomerId);
        public Account CheckAccountNumber(string sendingAccountNumber);
        public Account FindAccountByAccountNumber(string accountNumber);
    }
}
