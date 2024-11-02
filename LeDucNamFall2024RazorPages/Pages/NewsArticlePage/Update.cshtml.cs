using BusinessObject;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.NewsArticlePage
{
    public class UpdateModel : PageModel
    {
        private readonly INewsArticleRepository _newArticleRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateModel()
        {
            _newArticleRepository = new NewsArticleRepository();
            _categoryRepository = new CategoryRepository();
        }

        [BindProperty]
        public NewsArticle newsArticle { get; set; }
        public SelectList isActiveOptions { get; set; }
        public SelectList categoryList { get; set; }
        public async Task OnGet(string id)
        {
            await LoadData(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (newsArticle != null)
            {
                int? id = HttpContext.Session.GetInt32("UserId");
                short accountId = (short)id.Value;
                newsArticle.UpdatedById = accountId; 
                await _newArticleRepository.UpdateNew(newsArticle);
                TempData["Message"] = "Update oke";
                return Page();
            }
            else
            {
                TempData["Message"] = "Update fail";
                return Page();
            }
        }

        public async Task LoadData(string newsArticleId)
        {

            newsArticle = await _newArticleRepository.GetNewsById(newsArticleId);

            if (newsArticle == null)
            {
                TempData["Error"] = "News article not found.";
                return;
            }

            isActiveOptions = new SelectList(new List<SelectListItem>
             {
                 new SelectListItem { Value = "true", Text = "Active" },
                 new SelectListItem { Value = "false", Text = "Inactive" }
             }, "Value", "Text", newsArticle.NewsStatus?.ToString().ToLower());

            List<Category> cateList = await _categoryRepository.GetAllCategories();
            categoryList = new SelectList(cateList, "CategoryId", "CategoryName", newsArticle.CategoryId);

        }

    }
}

/*
  public string NewsArticleId { get; set; } = null!;
    public string? NewsTitle { get; set; }
    public string Headline { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public string? NewsContent { get; set; }
    pulic string? NewsSource { get; set; }
    public short? CategoryId { get; set; }
    public bool? NewsStatus { get; set; }
    public short? CreatedById { get; set; }
    public short? UpdatedById { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public virtual Category? Category { get; set; }
    public virtual SystemAccount? CreatedBy { get; set; }
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
 */