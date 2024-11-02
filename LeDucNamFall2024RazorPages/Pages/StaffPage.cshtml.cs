using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages
{
    public class StaffPageModel : PageModel
    {
        private readonly ISystemAccountRepository _systemAccountRepository;
        public StaffPageModel()
        {
            _systemAccountRepository = new SystemAccountRepository();
        }

        [BindProperty]
        public SystemAccount systemAccount { get; set; }
        

        public async Task OnGet()
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            short? accountId = (short)id.Value;
            systemAccount = await _systemAccountRepository.GetAccountById(accountId);
            
        }

        
    }
}
