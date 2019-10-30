using ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Documents.Tracking.Data.Entities
{
    public class ClientDocServices : EntityBase
    {
        [ForeignKey("ClientId")]
        public Clients ClientsId { get; set; }

        [ForeignKey("ServiceId")]
        public ServiceTasks ServiceTasksId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime FinishedDate { get; set; }

        [ForeignKey("DocStatusId")]
        public DocStatus CurrentDocStatusId { get; set; }
    }
}
