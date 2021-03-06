﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Contracts
{
    public interface IAdminManager : IBusinessLogicManager<Admin>  
    {
        public Admin MatchAdmin(string email, string password);
    }
}
