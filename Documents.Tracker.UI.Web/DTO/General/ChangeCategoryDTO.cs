using General.Services.Core.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
