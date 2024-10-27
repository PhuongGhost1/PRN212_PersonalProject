using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext _context;
        private static CandidateProfileDAO instance;
        public CandidateProfileDAO()
        {
            _context = new CandidateManagementContext();
        }

        public static CandidateProfileDAO getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        public bool CandidateProfileExists(string id)
        {
            return _context.CandidateProfiles.Any(e => e.CandidateId == id);
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return _context.CandidateProfiles.FirstOrDefault(x => x.CandidateId == id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return _context.CandidateProfiles.ToList();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile addCandidateProfile = GetCandidateProfile(candidateProfile.CandidateId);
            try
            {
                if (addCandidateProfile == null)
                {
                    _context.CandidateProfiles.Add(candidateProfile);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        public bool UpdateCandidateProfile(string id, CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            try
            {
                CandidateProfile updateCandidateProfile = GetCandidateProfile(id);
                if (updateCandidateProfile != null)
                {
                    updateCandidateProfile.Fullname = candidateProfile.Fullname;
                    updateCandidateProfile.Birthday = candidateProfile.Birthday;
                    updateCandidateProfile.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                    updateCandidateProfile.ProfileUrl = candidateProfile.ProfileUrl;
                    updateCandidateProfile.PostingId = candidateProfile.PostingId;
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }

        public bool DeleteCandidateProfile(string id)
        {
            bool isSuccess = false;
            CandidateProfile deleteCandidateProfile = GetCandidateProfile(id);
            try
            {
                if (deleteCandidateProfile != null)
                {
                    _context.CandidateProfiles.Remove(deleteCandidateProfile);
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
