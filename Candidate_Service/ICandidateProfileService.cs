using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public interface ICandidateProfileService
    {
        bool CheckCandidateProfileExists(string id);
        CandidateProfile GetCandidateProfile(string id);
        List<CandidateProfile> GetCandidateProfiles();
        bool AddCandidateProfile(CandidateProfile candidateProfile);
        bool UpdateCandidateProfile(string id, CandidateProfile candidateProfile);
        bool DeleteCandidateProfile(string id);
    }
}
