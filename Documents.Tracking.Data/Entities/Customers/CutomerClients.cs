using ApplicationCore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Documents.Tracking.Data.Entities
{
    public class CutomerClients : EntityBase
    {
        [ForeignKey("ClientsId")]
        public ICollection<Clients> ClientsId { get; set; }

    }
}
