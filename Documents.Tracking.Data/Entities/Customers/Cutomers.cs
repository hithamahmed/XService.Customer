using ApplicationCore.Entities;
using General.Services.Core.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Documents.Tracking.Data.Entities
{
    public class Cutomers : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string About { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
        [ForeignKey("CountriesId")]
        public Country Countryid { get; set; }
    }
}
