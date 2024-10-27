using Candidate_BusinessObject;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagementWebsite.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHrAccountService _service;

        public LoginModel(IHrAccountService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string email = Request.Form["txtUsername"];
            string password = Request.Form["txtPwd"];

            Hraccount account = _service.GetHrAccountsByEmailAsync(email);
            if (account != null && account.Password.Equals(password))
            {
                string RoleID = account.MemberRole.ToString();
                HttpContext.Session.SetString("RoleID", RoleID);
                Response.Redirect("/CandidateProfilePage");
            }
            else
            {
                Redirect("/Error");
            }
        }
    }
}
