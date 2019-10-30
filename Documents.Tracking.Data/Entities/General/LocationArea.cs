using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
namespace Documents.Tracking.Data.Entities
{
    public class LocationArea : EntityBase
    {
 
        public virtual Government Government { get; set; }
        public int GovernmentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
