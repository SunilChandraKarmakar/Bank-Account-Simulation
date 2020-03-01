using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;
using ProjectRepository.BaseRpository;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRepository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public override ICollection<Account> GetAll()
        {
            ICollection<Account> accountList = ourContext.Accounts
                                               .Include(a => a.AccountStatus)
                                               .Include(a => a.AccountType)
                                               .Include(a => a.Branch)
                                               .Include(a => a.Customer).ToList();
            return accountList;
        }

        [Obsolete]
        public List<CustomerNotInAccount> GetCustomerByBranchIdNotInAccount(int branchId)
        {
            List<CustomerNotInAccount> customers = ourContext.CustomerNotInAccounts
                                                   .Where(c => c.BranchId == branchId).ToList();
            return customers;
        }

        public Account GetAccountByIncluding(int? id)
        {
            Account aAccountDetails = ourContext.Accounts
                                              .Include(a => a.AccountStatus)
                                              .Include(a => a.AccountType)
                                              .Include(a => a.Branch)
                                              .Include(a => a.Customer)
                                              .Where(a=> a.Id == id)
                                              .FirstOrDefault();
            return aAccountDetails;
        }

        public Account GetLoginCustomerAccountByIncluding(int loginCustomerId)
        {
            Account loginCustomerAccountDetails = ourContext.Accounts
                                                  .Include(a => a.AccountStatus)
                                                  .Include(a => a.AccountType)
                                                  .Include(a => a.Branch)
                                                  .Include(a => a.Customer)
                                                  .Where(a => a.CustomerId == loginCustomerId).FirstOrDefault();
            return loginCustomerAccountDetails;
        }

        public Account CheckAccountNumber(string sendingAccountNumber)
        {
            Account checkAccountNumber = ourContext.Accounts.
                                        Where(a => a.AccountNumber == sendingAccountNumber).FirstOrDefault();
            return checkAccountNumber; 
        }

        public Account FindAccountByAccountNumber(string accountNumber)
        {
            Account findAccount = ourContext.Accounts
                                  .Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            return findAccount;
        }
    }
}
