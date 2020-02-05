using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ConsumerAddressOTO : CoreBaseOTO
    {
        public ConsumerAddressOTO()
        {
            CountriesList = new Collection<CountriesOTO>();
        }
        [Required] public int ConsumerId { get; set; }
        [Required] public int CountryId { get; set; }
        [Required] public int GovernmentId { get; set; }
        [Required] public int LocationAreaId { get; set; }
        [Required] [MaxLength(150)] public string Address1 { get; set; }
        [MaxLength(50)] public string Address2 { get; set; }
        [Required] [MaxLength(10)] public string BlockNo { get; set; }
        [Required] [MaxLength(10)] public string BuildingNo { get; set; }
        [Required] [MaxLength(10)] public string FloorNo { get; set; }
        [Required] [MaxLength(10)] public string FlatOfficeNo { get; set; }
        //public long? PhoneNumber { get; set; }
        public bool IsDefault { get; set; } = false;

        [AutoMapper.IgnoreMap]
        public ICollection<CountriesOTO> CountriesList { get; set; }
        [AutoMapper.IgnoreMap]
        public string FullLocation { get; set; }

    }
}
