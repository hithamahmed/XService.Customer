using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
namespace Documents.Tracking.Data.Entities
{
    public class Clients : EntityBase
    {

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = "";

        [MaxLength(20)]
        public string LastName { get; set; } = "";
        //[MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public long? MobileNumber { get; set; }

        [MaxLength(20)]
        [Required]
        public string IdentityId { get; set; } = "";

        [MaxLength(20)]
        public string PassportNumber { get; set; } = "";
    }
}
