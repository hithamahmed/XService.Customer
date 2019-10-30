using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Documents.Tracking.Data.Entities
{
    public class ClientServiceFollowUp : EntityBase
    {
        [ForeignKey("ClientId")]
        public Clients ClientsId { get; set; }

        [ForeignKey("ServiceId")]
        public ServiceTasks ServiceTasksId { get; set; }

        public DocRequirements DocRequirementsId { get; set; }

        [ForeignKey("DocStatusId")]
        public DocStatus CurrentDocStatusId { get; set; }
    }
}
