using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documents.Tracking.Data.Entities
{
    public class DocServices : EntityBase
    {

        [ForeignKey("ServiceCategoryId")]
        public virtual DocServiceCategory DocServiceCategory { get; set; }
        [Required]
        public int ServiceCategoryId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
       
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Price { get; set; }
        public string IconName { get; set; }

    }
}
