using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.AccountPage
{
    public class UpdateModel : PageModel
    {
        private readonly ISystemAccountRepository _systemAccountRepository;

        public UpdateModel()
        {
            _systemAccountRepository = new SystemAccountRepository();
        }
        [BindProperty]
        public SystemAccount systemAccount { get; set; }
        private string? email1 {  get; set; }
        private string? name1 { get; set; }
        public async Task OnGet(short id)
        {
            await LoadData(id);
            
        }

        public async Task OnPost()
        {
            
            await _systemAccountRepository.UpdateAccount(systemAccount);
            TempData["Message"] = "Update account successful";
        }
        private async Task LoadData(short id)
        {
            systemAccount = await _systemAccountRepository.GetAccountById(id);
            if (systemAccount != null) 
            {
                email1 = systemAccount.AccountEmail;
                name1 = systemAccount.AccountName;
            }
            else
            {
                TempData["Message"] = "Account not found.";
                return;
            }
        }
    }
}
