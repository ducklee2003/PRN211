using BusinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly TagDAO _tagDAO;

        public TagRepository()
        {
            _tagDAO = new TagDAO();
        }
        public async Task<List<Tag>> GetAllTags()
        {
            return await _tagDAO.GetAllTags();
        }

        public async Task<List<Tag>> GetTagByArticleId(string NewsArticleId)
        {
            return await _tagDAO.GetTagByArticleId(NewsArticleId);
        }

        public async Task DeleteAllTag(string newsArticleId)
        {
            await _tagDAO.DeleteNewTags(newsArticleId);
        }
        public async Task UpdateNewTag(string newsArticleId, int tagId, int updateTagID)
        {
            await _tagDAO.UpdateNewTag(newsArticleId, tagId, updateTagID);
        }

        public async Task AddTagsToNewsArticle(string newsArticleId, List<int> tagIds)
        {
            await _tagDAO.AddTagsToNewsArticle(newsArticleId, tagIds);
        }

        public async Task<ICollection<Tag>> GetTagsByIds(List<int> tagIds)
        {
            return await _tagDAO.GetTagsByIds(tagIds);
        }
    }
}
