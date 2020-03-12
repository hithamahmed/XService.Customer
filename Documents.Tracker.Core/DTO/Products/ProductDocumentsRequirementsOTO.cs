using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ProductDocumentsRequirementsOTO //: CoreBaseOTO
    {
        public int RefId { get; set; }
        [Required]
        public int ProductUKey { get; set; }

        [AutoMapper.IgnoreMap]
        [StringLength(50)]
        public string Name { get; set; }
        [AutoMapper.IgnoreMap]
        [StringLength(50)]
        public string Description { get; set; }

        public bool IsRequired { get; set; }
        [AutoMapper.IgnoreMap]
        public ProductOTO Product { get; set; }
        [Required] public int AttachmentFilesTypeId { get; set; }
    }
}
