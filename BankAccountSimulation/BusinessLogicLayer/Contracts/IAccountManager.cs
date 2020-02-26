using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts
{
    public interface IAccountManager : IBusinessLogicManager<Account>
    {
        public ICollection<Customer> GetCustomerByBranchId(int branchId);
        public Account GetAccountByIncluding(int? id);
    }
}
