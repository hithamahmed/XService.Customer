using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class APPConsumerDTO : CoreBaseDTO
    {
        [DisplayName("Full Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } private set { } }


        [MaxLength(20)]
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public int MobileNumber { get; set; }

        [MaxLength(20)]
        [DisplayName("Identity Number")]
        [Required]
        public string IdentityId { get; set; }

        [MaxLength(20)]
        public string PassportNumber { get; set; }
    }
}
