using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.UI.Web.DTO.General
{
    public class ChangeGovernmentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CountryId { get; set; }


        public int NewCountryId { get; set; }

        [Required]
        public string Name { get; set; }

        public SelectList CountriesSelectList { get; set; }
    }
}
