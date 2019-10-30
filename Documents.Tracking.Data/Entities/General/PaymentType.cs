using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
namespace Documents.Tracking.Data.Entities
{
    public class PaymentType : EntityBase
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
