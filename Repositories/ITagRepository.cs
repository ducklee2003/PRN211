using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllTags();
        Task<List<Tag>> GetTagByArticleId(string newsArticleId);
        Task DeleteAllTag(string newsArticleId);
        Task UpdateNewTag(string newsArticleId, int tagId, int updateTagID);
        Task AddTagsToNewsArticle(string newsArticleId, List<int> tagIds);
        Task<ICollection<Tag>> GetTagsByIds(List<int> tagIds);
    }
}
