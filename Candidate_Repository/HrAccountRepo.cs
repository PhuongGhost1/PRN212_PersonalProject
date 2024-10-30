using Candidate_BusinessObject;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class HrAccountRepo : IHrAccountRepo
    {
        public async Task<List<Hraccount>> GetAccounts() => HrAccountDAO.Instance.GetHraccounts();
         
        public async Task<Hraccount> GetHrAccountByEmail(string email) => HrAccountDAO.Instance.GetHrAccountByEmail(email);
    }
}
