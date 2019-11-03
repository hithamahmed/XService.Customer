using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ServiceDocumentsRequirementsDTO : DocumentBaseDTO
    {


        [Required]
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsRequired { get; set; }



    }
}
