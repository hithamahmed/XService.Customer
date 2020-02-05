using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ConsumerOTO 
    {
        public ConsumerOTO()
        {
            CounsumerAddresses = new List<ConsumerAddressOTO>();
        }

        public string RefId { get; set; }

        [DisplayName("Full Name")]
        //public string FullName { get { return $"{FirstName} {LastName}"; } private set { } }
        public string FullName { get; set; }
        public string UserName { get; set; }
        //[MaxLength(20)]
        //[DisplayName("First Name")]
        //[Required]
        //public string FirstName { get; set; }

        //[MaxLength(20)]
        //[DisplayName("Last Name")]
        //public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        [DisplayName("Identity Number")]
        [Required]
        [AutoMapper.IgnoreMap]
        public string IdentityId { get; set; }

        [MaxLength(20)]
        [AutoMapper.IgnoreMap]

        public string PassportNumber { get; set; }
        
        public ICollection<ConsumerAddressOTO> CounsumerAddresses { get; set; }
    }
}
