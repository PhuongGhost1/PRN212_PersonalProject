using Candidate_BusinessObject;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepo _candidateProfileRepo;
        public CandidateProfileService()
        {
            _candidateProfileRepo = new CandidateProfileRepo();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile) => _candidateProfileRepo.AddCandidateProfile(candidateProfile);

        public bool CheckCandidateProfileExists(string id) => _candidateProfileRepo.CheckCandidateProfileExists(id);

        public bool DeleteCandidateProfile(string id) => _candidateProfileRepo.DeleteCandidateProfile(id);

        public CandidateProfile GetCandidateProfile(string id) => _candidateProfileRepo.GetCandidateProfile(id);

        public List<CandidateProfile> GetCandidateProfiles() => _candidateProfileRepo.GetCandidateProfiles();

        public List<CandidateProfile> SearchByFullNameOrBirthday(string fullName, DateTime? birthday) => _candidateProfileRepo.SearchByFullNameOrBirthday(fullName, birthday);

        public bool UpdateCandidateProfile(string id, CandidateProfile candidateProfile) => _candidateProfileRepo.UpdateCandidateProfile(id, candidateProfile);
    }
}
