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
    public class NewsArticleDAO : SingletonBase<NewsArticleDAO>
    {
        public async Task<List<NewsArticle>> GetAllActiveNewsArticle()
        {
            return await _context.NewsArticles.Where(x => x.NewsStatus == true).OrderByDescending(x => x.CreatedDate).Include(x => x.CreatedBy).Include(x => x.Category).ToListAsync();
        }

        public async Task<bool> CheckCategoryExistInNews(short CategoryId)
        {
            return await _context.NewsArticles.AnyAsync(x => x.CategoryId == CategoryId);
        }

        public async Task<List<NewsArticle>> GetAllNewsArticle()
        {
            return await _context.NewsArticles.OrderByDescending(x => x.CreatedDate).Include(x => x.CreatedBy).Include(x => x.Category).ToListAsync();
        }

        public async Task<NewsArticle> GetNewsById(string newsArticleId)
        {
            return await _context.NewsArticles.Where(x => x.NewsArticleId == newsArticleId).Include(x => x.CreatedBy).Include(x => x.Category).FirstOrDefaultAsync();
        }

        public async Task<List<NewsArticle>> SearchNewByTitle(string newTitle)
        {
            return await _context.NewsArticles.Where(x => x.NewsTitle.Contains(newTitle)).ToListAsync();
        }

        public async Task DeleteNew(string newsArticleId)
        {
            var newDelete = await GetNewsById(newsArticleId);
            if (newDelete != null)
            {
                _context.NewsArticles.Remove(newDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateNew(NewsArticle newArticle)
        {
            var existingNewsArticle = await GetNewsById(newArticle.NewsArticleId);
            if (existingNewsArticle != null)
            {
                existingNewsArticle.NewsTitle = newArticle.NewsTitle;
                existingNewsArticle.Headline = newArticle.Headline;
                existingNewsArticle.NewsContent = newArticle.NewsContent;
                existingNewsArticle.NewsSource = newArticle.NewsSource;
                existingNewsArticle.ModifiedDate = DateTime.Now; 
                existingNewsArticle.CategoryId = newArticle.CategoryId;
                existingNewsArticle.NewsStatus = newArticle.NewsStatus;
                existingNewsArticle.UpdatedById = newArticle.UpdatedById;
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<NewsArticle>> GetNewsCreateByUserId(short createdById)
        {
            return await _context.NewsArticles.Where(x => x.CreatedById == createdById).OrderByDescending(x => x.CreatedDate).Include(x => x.CreatedBy).Include(x => x.Category).ToListAsync();
        }

        public async Task CreateNewArticle(NewsArticle newArticle)
        {
            _context.NewsArticles.Add(newArticle);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GenerateNewsId()
        {
            var id = await _context.NewsArticles.OrderByDescending(x => x.NewsArticleId).Select(x => x.NewsArticleId).FirstOrDefaultAsync();
            var numId = int.Parse(id) + 1;
            return numId.ToString();
        }

        public async Task<bool> CheckAccountInNews(short AccountId)
        {
            return await _context.NewsArticles.AnyAsync(x => x.CreatedById == AccountId || x.UpdatedById == AccountId);
        }

        //report
        public async Task<List<NewsArticle>> GetNewsForReport(DateTime startDate, DateTime endDate)
        {
            return await _context.NewsArticles.Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate).OrderByDescending(x => x.CreatedDate).ToListAsync();
        }
    }
}
