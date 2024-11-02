using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.NewsArticlePage
{
    public class ViewModel : PageModel
    {
        private readonly INewsArticleRepository _newsArticleRepository;
        public ViewModel()
        {
            _newsArticleRepository = new NewsArticleRepository();
        }

        [BindProperty]
        public NewsArticle NewsArticle { get; set; }

        public async Task OnGet(string id)
        {
            NewsArticle = await _newsArticleRepository.GetNewsById(id);
        }
    }
}
