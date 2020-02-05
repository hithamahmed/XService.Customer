using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Documents.Tracking.Data.Entities
{
    public class ClientServiceFollowUp : EntityBase
    {
        [ForeignKey("ConsumerId")]
        public Application.XIdentity.Core.CustomUser Clients { get; set; }
        [Required]public int ConsumerId { get; set; }

        [ForeignKey("ServiceId")]
        public ServiceTasks ServiceTasks { get; set; }
        [Required] public int ServiceId { get; set; }

        [Required] public DocRequirements DocRequirementsId { get; set; }

        [ForeignKey("CurrentStatusId")]
        public DocStatus CurrentStatus { get; set; }
        [Required] public int CurrentStatusId { get; set; }
    }
}
