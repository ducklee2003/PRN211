using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.CategoryPage
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly INewsArticleRepository _newsArticleRepository;

        public DeleteModel()
        {
            _categoryRepository = new CategoryRepository();
            _newsArticleRepository = new NewsArticleRepository();
        }

        [BindProperty]
        public Category category { get; set; }
        public async Task OnGet(short id)
        {
            await LoadData(id);
        }

        public async Task<IActionResult>  OnPost()
        {
            if (await _categoryRepository.CheckExistParentBeforeDelelte(category.CategoryId))
            {
                TempData["Message"] = "The category is a parent of another category";
                return Page();
            }

            if (await _newsArticleRepository.CheckCategoryInNews(category.CategoryId))
            {
                TempData["Message"] = "The category is still exist in new";
                return Page();
            }
            await _categoryRepository.DeleteCategory(category.CategoryId);
            TempData["Message"] = "The category is delete";
            return Page();
        }

        private async Task LoadData(short id)
        {
            category = await _categoryRepository.GetCategoryById(id);
        }
    }
}
