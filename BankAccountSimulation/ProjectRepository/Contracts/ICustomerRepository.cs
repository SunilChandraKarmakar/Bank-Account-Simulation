using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRepository.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public ICollection<Customer> GetCustomerWithBranch();
        public Customer ACustomerWithBranch(int? id);
        public string ExistEmail(string customerEmail);
    }
}
