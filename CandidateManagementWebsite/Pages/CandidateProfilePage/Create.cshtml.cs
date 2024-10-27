using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagementWebsite.Data;
using Candidate_BusinessObject;
using Candidate_Service;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService _service;
        private readonly IJobHostingService _jobService;
        public CreateModel(ICandidateProfileService service, IJobHostingService jobService)
        {
            _service = service;
            _jobService = jobService;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(_jobService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _service.GetCandidateProfiles() == null || CandidateProfile == null)
            {
                return Page();
            }

            _service.AddCandidateProfile(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
