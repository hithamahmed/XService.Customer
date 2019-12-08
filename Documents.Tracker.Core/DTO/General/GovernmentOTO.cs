using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class GovernmentOTO : CoreBaseOTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<LocationAreasOTO> LocationAreas { get; set; }
    }
}
