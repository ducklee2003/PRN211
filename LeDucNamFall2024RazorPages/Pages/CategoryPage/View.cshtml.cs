using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace LeDucNamFall2024RazorPages.Pages.CategoryPage
{
    public class ViewModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;

        public ViewModel()
        {
            _categoryRepository = new CategoryRepository(); 
        }

        [BindProperty]
        public List<Category> categories { get; set; }
        public async Task OnGet()
        {
            categories = await _categoryRepository.GetAllCategories();
        }
    }
}
