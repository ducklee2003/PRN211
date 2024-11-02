using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.AccountPage
{
    public class ViewProfileModel : PageModel
    {
        private readonly ISystemAccountRepository _systemAccountRepository;

        public ViewProfileModel()
        {
            _systemAccountRepository = new SystemAccountRepository();
        }

        [BindProperty]
        public SystemAccount systemAccount { get; set; }
        public async Task OnGet()
        {
            await LoadData();
        }

        public async Task OnPost()
        {
            await _systemAccountRepository.UpdateAccount(systemAccount);
            TempData["Message"] = "Update information successful";
        }

        public async Task LoadData()
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            short accountid = (short)id.Value;
            systemAccount = await _systemAccountRepository.GetAccountById(accountid);
        }
    }
}
