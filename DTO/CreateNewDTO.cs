using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CreateNewDTO
    {
        public string NewsArticleId { get; set; } = null!;

        public string? NewsTitle { get; set; }

        public string Headline { get; set; } = null!;

        public DateTime? CreatedDate { get; set; }

        public string? NewsContent { get; set; }

        public string? NewsSource { get; set; }

        public short? CategoryId { get; set; }

        public bool? NewsStatus { get; set; }

        public short? CreatedById { get; set; }

        public short? UpdatedById { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

        //public CreateNewDTO(string newsArticleId, string? newsTitle, string headline, DateTime? createdDate, string? newsContent, string? newsSource, short? categoryId, bool? newsStatus, short? createdById, short? updatedById, DateTime? modifiedDate)
        //{
        //    NewsArticleId = newsArticleId;
        //    NewsTitle = newsTitle;
        //    Headline = headline;
        //    CreatedDate = createdDate;
        //    NewsContent = newsContent;
        //    NewsSource = newsSource;
        //    CategoryId = categoryId;
        //    NewsStatus = newsStatus;
        //    CreatedById = createdById;
        //    UpdatedById = updatedById;
        //    ModifiedDate = modifiedDate;
        //}
    }
}
