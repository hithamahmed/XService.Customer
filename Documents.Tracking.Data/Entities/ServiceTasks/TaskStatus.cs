using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracking.Data.Entities
{
    public class TaskStatus : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}