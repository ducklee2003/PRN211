using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.NewsArticlePage
{
    public class CreateModel : PageModel
    {
        private readonly INewsArticleRepository _newArticleRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateModel()
        {
            _newArticleRepository = new NewsArticleRepository();
            _categoryRepository = new CategoryRepository();
        }

        [BindProperty]
        public NewsArticle newsArticle { get; set; }
        public SelectList isActiveOptions { get; set; }
        public SelectList categoryList { get; set; }
        public async Task OnGet()
        {
            await LoadData();
        }

        public async Task<IActionResult> OnPost()
        {
            if (newsArticle != null)
            {
                await _newArticleRepository.CreateNewArticle(newsArticle);
                await LoadData();
                TempData["Message"] = "Create news successfully";
                return Page();
            }
            else
            {
                await LoadData();
                TempData["Message"] = "Update fail";
                return Page();
            }
        }

        public async Task LoadData()
        {
            if (newsArticle == null)
                newsArticle = new NewsArticle(); 
            int? id = HttpContext.Session.GetInt32("UserId");
            short? accountId = (short?)id.Value;
            string newid = await _newArticleRepository.GenerateNewsId();
            if (string.IsNullOrEmpty(newid))
            {
                TempData["Message"] = "ID cannot create";
            }
            else
            {
                newsArticle.NewsArticleId = newid;
            newsArticle.CreatedById = accountId;
                newsArticle.CreatedDate = DateTime.Now;
                isActiveOptions = new SelectList(new List<SelectListItem>
             {
                 new SelectListItem { Value = "true", Text = "Active" },
                 new SelectListItem { Value = "false", Text = "Inactive" }
             }, "Value", "Text");

                List<Category> cateList = await _categoryRepository.GetAllCategories();
                categoryList = new SelectList(cateList, "CategoryId", "CategoryName");
            }

        }

    }
}

