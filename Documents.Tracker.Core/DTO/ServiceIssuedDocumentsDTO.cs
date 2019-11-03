using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ServiceIssuedDocumentsDTO : DocumentBaseDTO
    {

        [Required]
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

    }
}
