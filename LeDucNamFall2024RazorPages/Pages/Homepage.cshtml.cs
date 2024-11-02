using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages
{
    public class HomepageModel : PageModel
    {
        private readonly ISystemAccountRepository _accountRepository;
        private readonly INewsArticleRepository _newArticelRepository;

        public HomepageModel()
        {
            _newArticelRepository = new NewsArticleRepository();
        }
        [BindProperty]
        public List<NewsArticle> newsArticles { get; set; }
        public async Task OnGet()
        {
            newsArticles = await _newArticelRepository.GetNews();
        }
    }
}
