using Candidate_BusinessObject;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class JobHostingRepo : IJobHostingRepo
    {
        public bool AddJobHosting(JobPosting jobPosting) => JobPostingDAO.getInstance.AddJobHosting(jobPosting);

        public bool DeleteJobHosting(string id) => JobPostingDAO.getInstance.DeleteJobHosting(id);

        public JobPosting GetJobPosting(string id) => JobPostingDAO.getInstance.GetJobPosting(id);

        public List<JobPosting> GetJobPostings() => JobPostingDAO.getInstance.GetJobPostings();

        public bool UpdateJobHosting(JobPosting jobPosting) => JobPostingDAO.getInstance.UpdateJobHosting(jobPosting);
    }
}
