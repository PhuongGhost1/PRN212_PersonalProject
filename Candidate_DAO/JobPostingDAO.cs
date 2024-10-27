using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext _context;
        private static JobPostingDAO instance;
        public JobPostingDAO() 
        {
            _context = new CandidateManagementContext();
        }

        public static JobPostingDAO getInstance
        {
            get {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }

        public JobPosting GetJobPosting(string id)
        {
            return _context.JobPostings.SingleOrDefault(x => x.PostingId.Equals(id));
        }

        public List<JobPosting> GetJobPostings()
        {
            return _context.JobPostings.ToList();
        }

        public bool AddJobHosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting addJobPosting = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (addJobPosting != null)
                {
                    _context.JobPostings.Add(jobPosting);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        public bool UpdateJobHosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            JobPosting updateJobPosting = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (updateJobPosting != null)
                {
                    _context.JobPostings.Update(jobPosting);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        public bool DeleteJobHosting(string id)
        {
            bool isSuccess = false;
            JobPosting deleteJobPosting = GetJobPosting(id);
            try
            {
                if (deleteJobPosting != null)
                {
                    _context.JobPostings.Remove(deleteJobPosting);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }
    }
}
