using BusinessObject;
using DataAccess;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO : SingletonBase<CategoryDAO>
    {
        public async Task<List<Category>> GetAllCategory()
        {
            return await _context.Categories.Include(x => x.ParentCategory).ToListAsync();
        }
        public async Task<Category> GetCategoryById(short? categoryId)
        {
            var order = await _context.Categories.SingleOrDefaultAsync(x => x.CategoryId == categoryId);
            if (order == null) return null;
            return order;
        }
        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category();
            category.CategoryId = categoryDTO.CategoryId;
            category.CategoryName = categoryDTO.CategoryName;
            category.CategoryDesciption = categoryDTO.CategoryDesciption;
            category.ParentCategoryId = categoryDTO.ParentCategoryId;
            category.IsActive = categoryDTO.IsActive;
            var existItem = await GetCategoryById(category.CategoryId);
            if (existItem != null)           
                _context.Entry(existItem).CurrentValues.SetValues(category);               
            else       
                _context.Categories.Add(category);          
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategory(short categoryId)
        {
            var order = await GetCategoryById(categoryId);
            if (order != null)
            {
                _context.Categories.Remove(order);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<Category>> SearchCategoryByName(string categoryName)
        {
            return await _context.Categories.Where(x => x.CategoryName.Contains(categoryName)).ToListAsync();
        }

        public async Task<bool> CheckCategoryNameExist(string categoryName)
        {
            return await _context.Categories.AnyAsync(x => x.CategoryName == categoryName);
        }

        public async Task<string?> GetParentNameByParentId(short? ParentCategoryId)
        {
            return await _context.Categories.Where(x => x.CategoryId == ParentCategoryId).Select(x => x.CategoryName).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckParentIdExist(short CategoryId)
        {
            return await _context.Categories.AnyAsync(x => x.ParentCategoryId == CategoryId && x.CategoryId != CategoryId);
        }

        public async Task<short> GenerateCategoryID()
        {
            var id = await _context.Categories.OrderByDescending(x => x.CategoryId).Select(x => x.CategoryId).FirstOrDefaultAsync();
            return (short)(id + 1);
        }
    }
}
