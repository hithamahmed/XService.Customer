using ApplicationCore.Entities;
using General.Services.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Documents.Tracking.Data.Entities
{
    public class ConsumerServices : ApplicationCore.Entities.EntityBase
    {
        [ForeignKey("ConsumerId")]
        public virtual Application.XIdentity.Core.CustomUser Consumers { get; set; }
        public int ConsumerId { get; set; }

        [ForeignKey("ProductUKey")]
        public virtual Product Product { get; set; }
        public Guid ProductUKey { get; set; }


        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow.AddHours(3).Date;

        [DataType(DataType.Date)]
        public DateTime? FinishedDate { get; set; }


        [ForeignKey("CurrentServiceStatusId")]
        public virtual DocStatus CurrentServiceStatus { get; set; }
        public int CurrentServiceStatusId { get; set; }
    }
}
