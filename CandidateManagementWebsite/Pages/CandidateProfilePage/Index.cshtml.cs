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
using X.PagedList;
using X.PagedList.Extensions;

namespace CandidateManagementWebsite.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService _service;
        public IPagedList<CandidateProfile> CandidateProfiles { get; set; }
        public int PageNumber { get; set; }
        public IndexModel(ICandidateProfileService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime Birthday { get; set; }

        public async Task<IActionResult> OnGetAsync(int? pageNumber)
        {
            PageNumber = pageNumber ?? 1;
            int pageSize = 3;

            var candidatesQuery = _service.GetCandidateProfiles().AsQueryable();

            if (!string.IsNullOrEmpty(UserName))
            {
                candidatesQuery = candidatesQuery.Where(t => t.Fullname.Contains(UserName));
            }

            if (Birthday != DateTime.MinValue)
            {
                candidatesQuery = candidatesQuery.Where(t => t.Birthday.Value == Birthday.Date);
            }

            if (_service.GetCandidateProfiles() != null)
            {
                CandidateProfiles = candidatesQuery.ToPagedList(PageNumber, pageSize);
            }

            return Page();
        }
    }
}
