using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewArticleDTO
    {
        public string NewsArticleId { get; set; }

        public string? NewsTitle { get; set; }

        public string Headline { get; set; }

        public string? NewsContent { get; set; }

        public string? NewsSource { get; set; }

        public short? CategoryId { get; set; }

        public bool? NewsStatus { get; set; }

        public short? UpdatedById { get; set; }

        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        public NewArticleDTO()
        {
        }
        public NewArticleDTO(string newsArticleId, string? newsTitle, string headline, string? newsContent, string? newsSource, short? categoryId, bool? newsStatus, short? updatedById, DateTime? modifiedDate)
        {
            NewsArticleId = newsArticleId;
            NewsTitle = newsTitle;
            Headline = headline;
            NewsContent = newsContent;
            NewsSource = newsSource;
            CategoryId = categoryId;
            NewsStatus = newsStatus;
            UpdatedById = updatedById;
            ModifiedDate = modifiedDate;
        }
    }
}
