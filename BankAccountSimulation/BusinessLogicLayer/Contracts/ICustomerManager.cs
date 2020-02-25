using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Contracts
{
    public interface ICustomerManager : IBusinessLogicManager<Customer> 
    {
        public ICollection<Customer> GetCustomerWithBranch();
        public Customer ACustomerWithBranch(int? id);    
        public string ExistEmail(string customerEmail);
    }
}
