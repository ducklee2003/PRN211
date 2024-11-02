using BusinessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TagDAO : SingletonBase<TagDAO>
    {
        public async Task<List<Tag>> GetAllTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<ICollection<Tag>> GetTagsByIds(List<int> tagIds)
        {
            return await _context.Tags.Where(tag => tagIds.Contains(tag.TagId)).ToListAsync();
        }

        public async Task<List<Tag>> GetTagByArticleId(string NewsArticleId)
        {
            return await _context.NewsArticles.Where(x => x.NewsArticleId == NewsArticleId).SelectMany(x => x.Tags).ToListAsync();
        }

        public async Task DeleteNewTags(string newsArticleId)
        {
            var newsTags = await _context.Set<Dictionary<string, object>>("NewsTag")
            .Where(nt => nt["NewsArticleId"].ToString() == newsArticleId).ToListAsync();
            _context.RemoveRange(newsTags);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNewTag(string newsArticleId, int tagId, int updateTagID)
        {
            var newsTagsList = await _context.Set<Dictionary<string, object>>("NewsTag")
            .Where(nt => nt["NewsArticleId"].ToString() == newsArticleId).ToListAsync();

            var newsTag = newsTagsList.FirstOrDefault(nt => nt["NewsArticleId"].ToString() == newsArticleId
                       && Convert.ToInt32(nt["TagID"]) == tagId);
            if (newsTag != null)
            {
                newsTag["TagID"] = updateTagID;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddTagsToNewsArticle(string newsArticleId, List<int> tagIds)
        {
            foreach (var tagId in tagIds)
            {
                await AddTag(newsArticleId, tagId);
            }
        }

        private async Task AddTag(string newsArticleId, int tagIds)
        {
            var newsTag = new Dictionary<string, object>
                {
                    { "NewsArticleId", newsArticleId },
                    { "TagID", tagIds }
                };

            _context.Set<Dictionary<string, object>>("NewsTag").Add(newsTag);
            await _context.SaveChangesAsync();
        }
    }
}
