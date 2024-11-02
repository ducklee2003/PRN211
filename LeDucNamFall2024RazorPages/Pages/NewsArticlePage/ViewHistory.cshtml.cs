using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Repositories;
using System.Data;

namespace LeDucNamFall2024RazorPages.Pages.NewsArticlePage
{
    public class ViewHistoryModel : PageModel
    {
        private readonly INewsArticleRepository _newsArticleRepository;
        private readonly ISystemAccountRepository _systemaccountRepository;

        public ViewHistoryModel()
        {
            _newsArticleRepository = new NewsArticleRepository();
            _systemaccountRepository = new SystemAccountRepository();
        }

        [BindProperty]
        public List<NewsArticle> newsArticles { get; set; }

        public async Task<IActionResult> OnGet()
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            short accountId = (short)id.Value;
            var account = await _systemaccountRepository.GetAccountById(accountId);
            if (account.AccountRole == 2) 
            {
                return RedirectToPage("/LecturePage");
            }
            await LoadData(accountId);
            return Page();
        }

        public async Task LoadData(short accountId)
        {
            newsArticles = await _newsArticleRepository.GetNewsCreateByUserId(accountId);
        }
    }
}
