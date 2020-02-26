using Microsoft.EntityFrameworkCore;
using Models;
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

        public ICollection<Customer> GetCustomerByBranchId(int branchId)
        {
            List<Customer> customers = ourContext.Customers
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
    }
}
