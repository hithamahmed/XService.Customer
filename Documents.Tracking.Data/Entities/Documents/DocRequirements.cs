﻿using ApplicationCore.Entities;
using General.Services.Core.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documents.Tracking.Data.Entities
{
    public class DocRequirements : EntityBase
    {
        [ForeignKey("ServiceId")]
        public virtual ServiceCategory ServiceCategory { get; set; }
        [Required]
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public bool IsRequired { get; set; } = false;

    }
}
