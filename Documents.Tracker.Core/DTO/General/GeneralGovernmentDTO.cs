using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class GeneralGovernmentDTO : CoreBaseDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<GeneralLocationAreasDTO> LocationAreas { get; set; }
    }
}
