using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.UI.Web.DTO.General
{
    public class ChangeLocationAreaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int GovernmentId { get; set; }


        public int NewGovernmentId { get; set; }

        [Required]
        public string Name { get; set; }

        public SelectList GovernmentsSelectList { get; set; }
    }
}
