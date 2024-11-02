using BusinessObject;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<string> GetCategoryNameById(short? id);
        Task<List<Category>> GetAllCategories();
        Task UpdateCategory(CategoryDTO categoryDTO);
        Task DeleteCategory(short categoryId);
        Task<IEnumerable<Category>> GetCategoryByName(string categoryName);
        Task<bool> CheckCategoryNameExist(string categoryName); 
        Task CreateCategory(Category category);
        Task<string?> GetParentNameByParentId(short? parentId);
        Task<bool> CheckExistParentBeforeDelelte(short categoryId);
        Task<short> GenerateCategoryID();
        Task<Category> GetCategoryById(short categoryId);
    }
}
