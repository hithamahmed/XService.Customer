using ApplicationCore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Documents.Tracking.Data.Entities
{
    public class Country : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string DefaultLang { get; set; }

        public virtual ICollection<Government> Governments { get; set; }
    }
}
