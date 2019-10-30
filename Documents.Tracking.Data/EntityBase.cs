using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracking.Data
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Editable(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="yyyy-dd-MM")]
        public DateTime CreatedAt { get; set; }
        [Editable(false)]
        public string CreatedBy { get; set; }

        [Editable(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "yyyy-dd-MM")]
        public DateTime ModifiedAt { get; set; }
        [Editable(false)]
        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
