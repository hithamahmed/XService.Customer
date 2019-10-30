using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracking.Data.Entities
{
    public class TaskTypes : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
