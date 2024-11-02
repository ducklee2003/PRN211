using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.Xml.Linq;

namespace LeDucNamFall2024RazorPages.Pages.AccountPage
{
    public class CreateModel : PageModel
    {
        private readonly ISystemAccountRepository _systemAccountRepository;

        public CreateModel()
        {
            _systemAccountRepository = new SystemAccountRepository();
        }

        [BindProperty]
        public SystemAccount systemAccount { get; set; }

        public async Task OnPost()
        {
            if (!await _systemAccountRepository.ValidName(systemAccount.AccountName))
            {
                TempData["Message"] = "Please input correct type of name";
                return;
            }
            if (!await _systemAccountRepository.ValidGmail(systemAccount.AccountEmail))
            {
                TempData["Message"] = "Please input correct type of email";
                return;
            }
            if (await _systemAccountRepository.CheckEmail(systemAccount.AccountEmail))
            {
                TempData["Message"] = "Email is duplicate";
                return;
            }
            if (await _systemAccountRepository.CheckName(systemAccount.AccountName))
            {
                TempData["Message"] = "Name is duplicate";
                return;
            }
            systemAccount.AccountRole = 1;
            await _systemAccountRepository.CreateAccount(systemAccount);
            TempData["Message"] = "Create staff account successful";
            return;
        }

        public async Task OnGet()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            if (systemAccount == null)
                systemAccount = new SystemAccount(); 
            short id =  await _systemAccountRepository.GenerateAccountID();
            systemAccount.AccountId = id;
        }
    }
}
