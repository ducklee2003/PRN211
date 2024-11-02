using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.Configuration;

namespace LeDucNamFall2024RazorPages.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly IConfiguration _configuration;

        [BindProperty]
        
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }

        public LoginModel()
        {
            _systemAccountRepository = new SystemAccountRepository();
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                AccountEmail = username,
                AccountPassword = password
            };
            var adminEmail = _configuration["AdminAccount:AdminEmail"];
            var adminPassword = _configuration["AdminAccount:AdminPassword"];
           
            var account = await _systemAccountRepository.Login(loginDTO);
            if (account != null)
            {
                HttpContext.Session.SetInt32("UserId", account.AccountId);
                HttpContext.Session.SetInt32("AccountRole", account.AccountRole.Value);
                if (account.AccountRole == 1) return RedirectToPage("/StaffPage");    //EmmaWilliam@FUNewsManagement.org 
                if (account.AccountRole == 2) return RedirectToPage("/LecturePage"); //IsabellaDavid@FUNewsManagement.org
            }
            else if (username == adminEmail && password == adminPassword) // admin@FUNewsManagementSystem.org | @@abc123@@
            {
                HttpContext.Session.SetInt32("UserId", 0);
                HttpContext.Session.SetInt32("AccountRole", 0);
                return RedirectToPage("/AdminPage");
            }
            else
            {
                TempData["Message"] = "Username or password not correct";
                return Page();
            }
            
            return RedirectToPage("/Homepage");
        }
    }
}
