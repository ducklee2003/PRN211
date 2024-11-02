using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryDTO
    {
        public short CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string CategoryDesciption { get; set; } = null!;

        public short? ParentCategoryId { get; set; }

        public bool? IsActive { get; set; }
        public CategoryDTO()
        {
        }
        public CategoryDTO(short categoryId, string categoryName, string categoryDesciption, short? parentCategoryId, bool? isActive)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            CategoryDesciption = categoryDesciption;
            ParentCategoryId = parentCategoryId;
            IsActive = isActive;
        }
    }
}
