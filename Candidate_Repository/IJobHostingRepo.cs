using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public interface IJobHostingRepo
    {
        JobPosting GetJobPosting(string id);
        List<JobPosting> GetJobPostings();
        bool AddJobHosting(JobPosting jobPosting);
        bool UpdateJobHosting(JobPosting jobPosting);
        bool DeleteJobHosting(string id);
    }
}
