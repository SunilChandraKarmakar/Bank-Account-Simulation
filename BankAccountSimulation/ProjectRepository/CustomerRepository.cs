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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository 
    {
        public ICollection<Customer> GetCustomerWithBranch()
        {
            List<Customer> getCustomerWithBranch = ourContext.Customers
                                                   .Include(c => c.Branch).ToList();
            return getCustomerWithBranch;
        }

        public Customer ACustomerWithBranch(int? id)
        {
            Customer aCustomerWithBranch = ourContext.Customers
                                            .Include(c => c.Branch)
                                            .Where(c => c.Id == id).FirstOrDefault();
            return aCustomerWithBranch;
        }

        public string ExistEmail(string customerEmail)
        {
            Customer aCustomerInfo = ourContext.Customers
                                    .Where(c => c.Email == customerEmail).FirstOrDefault();
            string existEmail = aCustomerInfo.Email;
            return existEmail;
        }

        public Customer MatchCustomer(string email, string password)
        {
            Customer loginCustomerDetails = ourContext.Customers
                                            .Where(c => c.Email == email && c.Password == password).FirstOrDefault();
            return loginCustomerDetails;
        }
    }
}
