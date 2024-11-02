using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.AccountPage
{
    public class ViewModel : PageModel
    {
        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly INewsArticleRepository _newsArticleRepository;
        public ViewModel()
        {
            _systemAccountRepository = new SystemAccountRepository();
            _newsArticleRepository = new NewsArticleRepository();
        }
        [BindProperty]
        public List<SystemAccount> systemAccounts { get; set; }

        public async Task OnGet()
        {
            await LoadData();
        }

        public async Task<IActionResult> OnPostDeleteAccount(short id)
        {
            var account = await _systemAccountRepository.GetAccountById(id);
            if (account != null)
            {
                if (await _newsArticleRepository.CheckAccountInNews(account.AccountId))
                {
                    TempData["Message"] = "Account cannot delete because is in news";
                    return RedirectToPage();
                }
                await _systemAccountRepository.DeleteAccount(id);
                TempData["Message"] = "Delete account successfull";
                return RedirectToPage();
            }
            else
            {
                TempData["Message"] = "Delete account fail";
                return RedirectToPage();
            }

        }

        private async Task LoadData()
        {
            systemAccounts = await _systemAccountRepository.GetAllSystemAccount();
        }
    }
}
