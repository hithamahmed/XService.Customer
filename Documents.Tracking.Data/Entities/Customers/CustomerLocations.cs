using ApplicationCore.Entities;
using General.Services.Core.Entity;

namespace Documents.Tracking.Data.Entities
{
    public class CustomerLocations : EntityBase
    {
        public LocationArea LocationAreasId { get; set; }

    }
}
