using ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Documents.Tracking.Data.Entities
{
    public class ClientPayments : EntityBase
    {
        [ForeignKey("ClientId")]
        public Clients ClientsId { get; set; }
       [ForeignKey("ServiceId")]
        public ServiceTasks ServiceTasksId { get; set; }
        public PaymentType PaymentTypesId { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        [Column(TypeName = "decimal(18, 3)")]
        public decimal PaidAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        [MaxLength(100)]
        public string ReferenceCode { get; set; }

    }
}
