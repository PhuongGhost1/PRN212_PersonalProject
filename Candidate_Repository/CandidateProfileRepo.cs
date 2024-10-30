using Candidate_BusinessObject;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.getInstance.AddCandidateProfile(candidateProfile);

        public bool CheckCandidateProfileExists(string id) => CandidateProfileDAO.getInstance.CandidateProfileExists(id);

        public bool DeleteCandidateProfile(string id) => CandidateProfileDAO.getInstance.DeleteCandidateProfile(id);

        public CandidateProfile GetCandidateProfile(string id) => CandidateProfileDAO.getInstance.GetCandidateProfile(id);

        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.getInstance.GetCandidateProfiles();

        public List<CandidateProfile> SearchByFullNameOrBirthday(string fullName, DateTime? birthday) => CandidateProfileDAO.getInstance.SearchByFullNameOrBirthday(fullName, birthday);

        public bool UpdateCandidateProfile(string id,CandidateProfile candidateProfile) => CandidateProfileDAO.getInstance.UpdateCandidateProfile(id, candidateProfile);
    }
}
