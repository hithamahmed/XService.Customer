using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ProductOTO : CoreBaseOTO
    {
        [MaxLength(200)]
        public string ProductUKey { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string NameAr { get; set; }

        [MaxLength(25)]
        public string ShortName { get; set; }

        [MaxLength(150)]
        public string Details { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        public decimal Price { get; set; }


        //public int? AvailableStock { get; set; } = 0;

        public CategoriesOTO Category { get; set; }

        [AutoMapper.IgnoreMap]
        public ICollection<CategoriesOTO> Categories { get; set; }

        [AutoMapper.IgnoreMap]
        public ICollection<ProductDocumentsRequirementsOTO> ProductDocumentsRequirements { get; set; }
        [AutoMapper.IgnoreMap]
        public ICollection<ProductIssuedDocumentsOTO> ProductIssuedDocuments { get; set; }

        public string GetProductName()
        {
            return Name;
        }
        public string GetProductShortName()
        {
            return ShortName;
        }
    }
}
