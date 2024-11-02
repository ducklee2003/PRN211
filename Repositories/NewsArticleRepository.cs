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
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly NewsArticleDAO _newsArticleDAO;

        public NewsArticleRepository() 
        { 
            _newsArticleDAO = new NewsArticleDAO();
        }
        public async Task<List<NewsArticle>> GetNews()
        {
            return await _newsArticleDAO.GetAllActiveNewsArticle();
        }

        public async Task<List<NewsArticle>> GetAllNews()
        {
            return await _newsArticleDAO.GetAllNewsArticle();
        }

        public async Task<bool> CheckCategoryInNews(short categoryId)
        {
            return await _newsArticleDAO.CheckCategoryExistInNews(categoryId);
        }

        public async Task UpdateNew(NewsArticle newArticle)
        {
            await _newsArticleDAO.UpdateNew(newArticle);
        }
        public async Task DeleteNew(string newsArticleId)
        {
            await _newsArticleDAO.DeleteNew(newsArticleId);
        }

        public async Task<List<NewsArticle>> SearchNews(string newTitle)
        {
            return await _newsArticleDAO.SearchNewByTitle(newTitle);
        }

        public async Task<NewsArticle> GetNewsById(string newsArticleId)
        {
            return await _newsArticleDAO.GetNewsById(newsArticleId);
        }

        public async Task<List<NewsArticle>> GetNewsCreateByUserId(short userId)
        {
            return await _newsArticleDAO.GetNewsCreateByUserId(userId);
        }

        public async Task CreateNewArticle(NewsArticle newArticle)
        {
            await _newsArticleDAO.CreateNewArticle(newArticle);
        }

        public async Task<string> GenerateNewsId()
        {
            return await _newsArticleDAO.GenerateNewsId();
        }

        public async Task<bool> CheckAccountInNews(short accountId)
        {
            return await _newsArticleDAO.CheckAccountInNews(accountId);
        }

        public async Task<List<NewsArticle>> GetNewsForReport(DateTime startDate, DateTime endDate)
        {
            return await _newsArticleDAO.GetNewsForReport(startDate, endDate);
        }
    }
}
