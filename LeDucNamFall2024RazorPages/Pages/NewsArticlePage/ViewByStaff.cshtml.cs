using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.NewsArticlePage
{
    public class ViewByStaffModel : PageModel
    {
        private readonly INewsArticleRepository _newArticelRepository;
        public ViewByStaffModel()
        {
            _newArticelRepository = new NewsArticleRepository();
        }
        [BindProperty]
        public List<NewsArticle> newsArticles { get; set; }
        public async Task OnGet()
        {
            await LoadData();
        }

        
        public async Task LoadData()
        {
            newsArticles = await _newArticelRepository.GetAllNews();
        }
    }
}

