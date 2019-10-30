using ApplicationCore.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Documents.Tracking.Data.Entities
{
    public class ClientDocAttachments : EntityBase
    {
        [ForeignKey("ClientId")]
        public Clients ClientsId { get; set; }
        [ForeignKey("ServiceId")]
        public ServiceTasks ServiceTasksId { get; set; }
        public DocRequirements DocRequirementsId { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        public DateTime AttachDate { get; set; }



    }
}
