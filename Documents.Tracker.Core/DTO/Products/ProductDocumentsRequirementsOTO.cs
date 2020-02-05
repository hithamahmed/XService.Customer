﻿using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ProductDocumentsRequirementsOTO : CoreBaseOTO
    {


        [Required]
        public int ProductUKey { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsRequired { get; set; }
        [AutoMapper.IgnoreMap]
        public ProductOTO Product { get; set; }


    }
}