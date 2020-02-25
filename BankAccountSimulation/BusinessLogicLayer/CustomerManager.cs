using BusinessLogicLayer.BaseBLL;
using BusinessLogicLayer.Contracts;
using Models;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class CustomerManager : BaseManager<Customer>, ICustomerManager  
    {
        private readonly ICustomerRepository _iCustomerRepository;

        public CustomerManager(ICustomerRepository iCustomerRepository) : base(iCustomerRepository)
        {
            _iCustomerRepository = iCustomerRepository;
        }

        public ICollection<Customer> GetCustomerWithBranch()
        {
            return _iCustomerRepository.GetCustomerWithBranch();
        }

        public Customer ACustomerWithBranch(int? id)
        {
            return _iCustomerRepository.ACustomerWithBranch(id);
        }

        public string ExistEmail(string customerEmail)
        {
            return _iCustomerRepository.ExistEmail(customerEmail);
        }
    }
}
