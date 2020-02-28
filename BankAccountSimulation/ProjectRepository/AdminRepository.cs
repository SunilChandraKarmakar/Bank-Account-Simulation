using Models;
using ProjectRepository.BaseRpository;
using ProjectRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRepository
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public Admin MatchAdmin(string email, string password)
        {
            return ourContext.Admins
                  .Where(a => a.Email == email && a.Password == password).FirstOrDefault();
        }
    }
}
