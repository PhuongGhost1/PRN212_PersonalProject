using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagementWebsite.Data;
using Candidate_BusinessObject;
using Candidate_Service;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _service;

        public IndexModel(ICandidateProfileService service)
        {
            _service = service;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service.GetCandidateProfiles() != null)
            {
                CandidateProfile = _service.GetCandidateProfiles();
            }
        }
    }
}
