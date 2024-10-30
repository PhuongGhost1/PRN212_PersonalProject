using Candidate_BusinessObject;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class HrAccountService : IHrAccountService
    {
        private IHrAccountRepo _hrAccountRepo;
        public HrAccountService()
        {
            _hrAccountRepo = new HrAccountRepo();
        }
        public Task<List<Hraccount>> GetHraccountsAsync() => _hrAccountRepo.GetAccounts();

        public async Task<Hraccount> GetHrAccountsByEmailAsync(string email) => await _hrAccountRepo.GetHrAccountByEmail(email);
    }
}
