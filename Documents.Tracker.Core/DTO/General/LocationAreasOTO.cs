using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class LocationAreasOTO : CoreBaseOTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
