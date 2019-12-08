using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class CountriesOTO : CoreBaseOTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string DefaultLang { get; set; }
        public ICollection<GovernmentOTO> Governments { get; set; }
    }
}
