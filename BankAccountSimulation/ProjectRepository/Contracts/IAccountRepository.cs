using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository.Contracts
{
    public interface IAccountRepository : IRepository<Account>
    {
        public ICollection<Customer> GetCustomerByBranchId(int branchId);
        public Account GetAccountByIncluding(int? id);
    }
}
