using ApplicationCore.Entities;
using General.Services.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracking.Data.Entities
{
    public class CustomerBranches : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public LocationArea LocationAreaId { get; set; }
        public bool IsMainOffice { get; set; }
    }
}
