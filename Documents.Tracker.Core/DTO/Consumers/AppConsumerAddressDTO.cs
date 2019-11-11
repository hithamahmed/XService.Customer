using General.Services.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class AppConsumerAddressDTO : CoreBaseDTO
    {
        [Required] public int ConsumerId { get; set; }
        [Required] public int CountryId { get; set; }
        [Required] public int GovernmentId { get; set; }
        [Required] public int LocationAreaId { get; set; }
        [Required] [MaxLength(150)] public string Address1 { get; set; }
        public long? PhoneNumber { get; set; }
        public bool IsDefault { get; set; } = false;

        [AutoMapper.IgnoreMap]
        public ICollection<GeneralCountriesDTO> CountriesList { get; set; }
        [AutoMapper.IgnoreMap]
        public string FullLocation { get; set; }
 
    }
}
