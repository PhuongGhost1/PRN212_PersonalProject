using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class HrAccountDAO
    {
        private CandidateManagementContext context;
        private static HrAccountDAO instance;
        public HrAccountDAO()
        {
            context = new CandidateManagementContext();
        }

        public static HrAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HrAccountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetHrAccountByEmail(string email)
        {
            return context.Hraccounts.SingleOrDefault(h => h.Email.Equals(email));
        }

        public List<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }
    }
}
