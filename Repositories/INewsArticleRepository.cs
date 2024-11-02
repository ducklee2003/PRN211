using BusinessObject;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface INewsArticleRepository
    {
        Task<List<NewsArticle>> GetNews();
        Task<List<NewsArticle>> GetAllNews();
        Task<bool> CheckCategoryInNews(short categoryId);
        Task UpdateNew(NewsArticle newsArticle);
        Task DeleteNew(string newsArticleId);
        Task<List<NewsArticle>> SearchNews(string newTitle);
        Task<NewsArticle> GetNewsById(string newsArticleId);
        Task<List<NewsArticle>> GetNewsCreateByUserId(short userId);
        Task CreateNewArticle(NewsArticle newArticle);
        Task<string> GenerateNewsId();
        Task<bool> CheckAccountInNews(short AccountId);
        Task<List<NewsArticle>> GetNewsForReport(DateTime startDate, DateTime endDate);
    }
}
