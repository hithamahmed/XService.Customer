using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class CategoriesOTO : CoreBaseOTO
    {
        public CategoriesOTO()
        {
            SubCategories = new List<CategoriesOTO>();
        }
        public int? ParentCategoryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(250)]
        public string ImageUrl { get; set; }

        //[AutoMapper.IgnoreMap]
        //public CategoriesOTO ParentCategory { get; set; }

        public ICollection<CategoriesOTO> SubCategories { get; set; }
        //public ICollection<ProductOTO> Products { get; set; }

    }
}
