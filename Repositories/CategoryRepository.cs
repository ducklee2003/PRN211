using BusinessObject;
using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _categoryDAO;

        public CategoryRepository()
        {
            _categoryDAO = new CategoryDAO();
        }
        public async Task<string> GetCategoryNameById(short? id)
        {
            var category = await _categoryDAO.GetCategoryById(id);
            return category.CategoryName;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryDAO.GetAllCategory();
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            await _categoryDAO.UpdateCategory(categoryDTO);
        }

        public async Task DeleteCategory(short categoryId)
        {
            await _categoryDAO.DeleteCategory(categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategoryByName(string categoryName)
        {
            return await _categoryDAO.SearchCategoryByName(categoryName);
        }
        
        public async Task<bool> CheckCategoryNameExist(string categoryName)
        {
            return await _categoryDAO.CheckCategoryNameExist(categoryName);
        }

        public async Task CreateCategory(Category category)
        {
            await _categoryDAO.AddCategory(category);
        }

        public async Task<string?> GetParentNameByParentId(short? parentId)
        {
            return await _categoryDAO.GetParentNameByParentId(parentId);
        }

        public async Task<bool> CheckExistParentBeforeDelelte(short categoryId)
        {
            return await _categoryDAO.CheckParentIdExist(categoryId);
        }
        public async Task<short> GenerateCategoryID()
        {
            return await _categoryDAO.GenerateCategoryID();
        }

        public async Task<Category> GetCategoryById(short categoryId)
        {
            return await _categoryDAO.GetCategoryById(categoryId);
        }
    }
}
