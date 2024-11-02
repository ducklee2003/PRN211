using BusinessObject;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;
using System.Xml.Linq;

namespace LeDucNamFall2024RazorPages.Pages.CategoryPage
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateModel()
        {
            _categoryRepository = new CategoryRepository();
        }
        [BindProperty]
        public Category category { get; set; }
        public SelectList parentList { get; set; }
        public SelectList isActiveOptions { get; set; }
        public async Task OnGet()
        {
            await LoadData();
        }

        public async Task<IActionResult> OnPost()
        {
            if (category != null)
            {
                if(await _categoryRepository.CheckCategoryNameExist(category.CategoryName))
                {
                    await LoadData();
                    TempData["Message"] = "Please enter another name";
                    return Page();
                }
                else
                {
                    await _categoryRepository.CreateCategory(category);
                    await LoadData();
                    TempData["Message"] = "Create new category successfully";
                    return Page();
                }
            }
            else
            {
                await LoadData();
                TempData["Message"] = "Update fail";
                return Page();
            }
        }

        private async Task LoadData()
        {
            List<Category> categories = await _categoryRepository.GetAllCategories();
            parentList = new SelectList(categories, "CategoryId", "CategoryName");
            isActiveOptions = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "true", Text = "Active" },
                new SelectListItem { Value = "false", Text = "Inactive" }
            }, "Value", "Text");
        }
    }
}
