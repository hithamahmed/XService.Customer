using General.Services.Core.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.DTO
{
    public class ChangeCategoryDTO : GeneralBaseDTO
    {

        [Required]
        public int ServiceCategoryId { get; set; }

        
        public int NewServiceCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public SelectList CategoriesSelectList { get; set; }
    }
}
