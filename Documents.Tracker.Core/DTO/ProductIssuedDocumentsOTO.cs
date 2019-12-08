using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ProductIssuedDocumentsOTO : DocumentBaseOTO
    {

        [Required]
        public int ProductUKey { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public ProductOTO Product { get; set; }

    }
}
