using Candidate_BusinessObject;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class JobHostingService : IJobHostingService
    {
        private IJobHostingRepo _jobHostingRepo;
        public JobHostingService() 
        {
            _jobHostingRepo = new JobHostingRepo();
        }
        public bool AddJobHosting(JobPosting jobPosting) => _jobHostingRepo.AddJobHosting(jobPosting);

        public bool DeleteJobHosting(string id) => _jobHostingRepo.DeleteJobHosting(id);

        public JobPosting GetJobPosting(string id) => _jobHostingRepo.GetJobPosting(id);

        public List<JobPosting> GetJobPostings() => _jobHostingRepo.GetJobPostings();

        public bool UpdateJobHosting(JobPosting jobPosting) => _jobHostingRepo.UpdateJobHosting(jobPosting);
    }
}
