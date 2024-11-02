using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.ReportPage
{
    public class ViewModel : PageModel
    {
        private readonly INewsArticleRepository _newArticleRepository;

        public ViewModel()
        {
            _newArticleRepository = new NewsArticleRepository();
        }
        [BindProperty] 
        public DateTime StartDate { get; set; }
        [BindProperty]
        public DateTime EndDate { get; set; }
        [BindProperty]
        public List<NewsArticle> NewsArticles { get; set; }
        public void OnGet()
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }

        public async Task<IActionResult> OnPost()
        {
            if(StartDate != null && EndDate != null)
            {
                NewsArticles = await _newArticleRepository.GetNewsForReport(StartDate, EndDate);
                TempData["Message"] = "Create report successful";
                return Page();
            }
            else
            {
                TempData["Message"] = "Cannot create report";
                return Page();
            }
        }
    }
}
