using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRepository.Contracts
{
    public interface IAdminRepository : IRepository<Admin>
    {
        public Admin MatchAdmin(string email, string password);
    }
}
