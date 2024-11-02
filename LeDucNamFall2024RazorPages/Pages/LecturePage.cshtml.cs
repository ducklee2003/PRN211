using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages
{
    public class LecturePageModel : PageModel
    {
        private readonly ISystemAccountRepository _accountRepository;
        private readonly INewsArticleRepository _newArticelRepository;

        public LecturePageModel()
        {
            _accountRepository = new SystemAccountRepository();
            _newArticelRepository = new NewsArticleRepository();
        }
        [BindProperty]
        public string AccountName { get; set; }
        [BindProperty]
        public List<NewsArticle> newsArticles { get; set; }
        public async Task OnGet()
        {
            int? accountId = HttpContext.Session.GetInt32("UserId");

            if (accountId.HasValue)
            {
                short id = (short)accountId.Value;
                var account = await _accountRepository.GetAccountById(id);
                AccountName = account.AccountName;
                newsArticles = await _newArticelRepository.GetNews();
            }
            else
            {
                AccountName = "ko co";
            }
        }
    }
}
