using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NewsDetailDTO
    {
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }    
        public NewsArticle NewsArticle { get; set; }

        public NewsDetailDTO(string authorName, string categoryName, NewsArticle newsArticle)
        {
            AuthorName = authorName;
            CategoryName = categoryName;
            NewsArticle = newsArticle;
        }
    }
}
