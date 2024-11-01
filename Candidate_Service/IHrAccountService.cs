﻿using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public interface IHrAccountService
    {
        Task<List<Hraccount>> GetHraccountsAsync();
        Task<Hraccount> GetHrAccountsByEmailAsync(string email);
    }
}
