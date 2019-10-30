using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
namespace Documents.Tracking.Data.Entities
{
    public class Government : EntityBase
    {
        
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
