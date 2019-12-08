using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documents.Tracking.Data.Entities
{
    public class DocStatus : EntityBase
    {
        public DocStatus()
        {
            ParentDocStatus = new DocStatus();
        }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("ParentServiceStatusid")]
        public  DocStatus ParentDocStatus { get; set; }
        public int? ParentDocStatusid { get; set; }
    }
}
