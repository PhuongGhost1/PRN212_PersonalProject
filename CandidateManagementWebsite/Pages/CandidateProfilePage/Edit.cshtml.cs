using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandidateManagementWebsite.Data;
using Candidate_BusinessObject;
using Candidate_Service;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileService _service;
        private readonly IJobHostingService _jobService;
        public EditModel(ICandidateProfileService service, IJobHostingService jobService)
        {
            _service = service;
            _jobService = jobService;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateprofile = _service.GetCandidateProfile(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
           ViewData["PostingId"] = new SelectList(_jobService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var candidateprofile = _service.GetCandidateProfile(id);
            if(candidateprofile != null)
            {
                _service.UpdateCandidateProfile(id, CandidateProfile);
            }

            return RedirectToPage("./Index");
        }

        private bool CandidateProfileExists(string id)
        {
            return _service.CheckCandidateProfileExists(id);
        }
    }
}
