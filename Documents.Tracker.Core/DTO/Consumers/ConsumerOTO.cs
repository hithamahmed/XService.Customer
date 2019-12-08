using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ConsumerOTO : CoreBaseOTO
    {
        public ConsumerOTO()
        {
            CounsumerAddresses = new List<ConsumerAddressOTO>();
        }
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
        public long MobileNumber { get; set; }

        [MaxLength(20)]
        [DisplayName("Identity Number")]
        [Required]
        public string IdentityId { get; set; }

        [MaxLength(20)]
        public string PassportNumber { get; set; }

        public ICollection<ConsumerAddressOTO> CounsumerAddresses { get; set; }
    }
}
