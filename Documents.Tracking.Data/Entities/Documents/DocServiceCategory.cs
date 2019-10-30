using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
namespace Documents.Tracking.Data.Entities
{
    public class DocServiceCategory : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string IconName { get; set; }

    }
}
