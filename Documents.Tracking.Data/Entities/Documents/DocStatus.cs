using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documents.Tracking.Data.Entities
{
    public class DocStatus : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("DependOnStatusid")]
        public virtual DocStatus DependOn { get; set; }
        public int? DependOnStatusid { get; set; }
    }
}
