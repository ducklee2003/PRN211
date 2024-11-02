using BusinessObject;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.CategoryPage
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateModel()
        {
            _categoryRepository = new CategoryRepository();
        }

        [BindProperty]
        public Category category { get; set; }
        public SelectList parentList { get; set; }
        public SelectList isActiveOptions { get; set; }

        public async Task OnGet(short id)
        {
            await LoadData(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(category == null)
            {
                await LoadData(category.CategoryId);
                TempData["Message"] = "Update fail";
                return Page();
            }
            CategoryDTO categoryDTO = new CategoryDTO(category.CategoryId, category.CategoryName, category.CategoryDesciption, category.ParentCategoryId, category.IsActive);
            await _categoryRepository.UpdateCategory(categoryDTO);
            await LoadData(category.CategoryId);
            TempData["Message"] = "Update successfull";
            return Page();
        }

        private async Task LoadData(short id)
        {
            category = await _categoryRepository.GetCategoryById(id);
            List<Category> categories = await _categoryRepository.GetAllCategories();
            parentList = new SelectList(categories, "CategoryId", "CategoryName");
            isActiveOptions = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "true", Text = "Active" },
                new SelectListItem { Value = "false", Text = "Inactive" }
            }, "Value", "Text", category.IsActive.ToString().ToLower());
        }
    }
}
