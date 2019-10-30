using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
namespace Documents.Tracking.Data.Entities
{
    public class Clients : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string Mobilenumber { get; set; }
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string IdentifierIdNumber { get; set; }
        public bool AppBlocked { get; set; } = false;


    }
}
