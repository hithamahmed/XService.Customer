using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class LocationAreasOTO : CoreBaseOTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
