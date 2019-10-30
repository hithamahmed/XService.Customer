using ApplicationCore.Entities;
using General.Services.Core.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Documents.Tracking.Data.Entities
{
    public class ClientAddress : EntityBase
    {
        public int ClientId { get; set; }
        public int GovernmentId { get; set; }
        public int LocationAreaId { get; set; }
        public int CountryId { get; set; }

        public virtual Clients Clients { get; set; }
        public virtual Country Countries { get; set; }
        public virtual Government Governments { get; set; }
        public virtual LocationArea LocationArea { get; set; }

        [MaxLength(50)]
        public string Address1 { get; set; }
        [MaxLength(50)]
        public string Address2 { get; set; }
        [MaxLength(10)]
        public string BlockNo { get; set; }
        [MaxLength(10)]
        public string BuildingNo { get; set; }
        [MaxLength(10)]
        public string FloorNo { get; set; }
        [MaxLength(10)]
        public string FlatOfficeNo { get; set; }
        public bool IsDefault { get; set; }
    }
}
