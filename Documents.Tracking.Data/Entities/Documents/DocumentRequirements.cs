using ApplicationCore.Entities;
using General.Services.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documents.Tracking.Data.Entities
{
    [Table(name: "DocRequirements")]
    public class DocumentRequirements : EntityBase
    {
        [ForeignKey("ProductUKey")]
        //[NotMapped]
        public virtual Product Product { get; set; }
        [Required]
        public int ProductUKey { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public bool IsRequired { get; set; } = false;

    }
}
