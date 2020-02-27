using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts
{
    public interface IAccountManager : IBusinessLogicManager<Account>
    {
        public List<CustomerNotInAccount> GetCustomerByBranchIdNotInAccount(int branchId);
        public Account GetAccountByIncluding(int? id);
    }
}
