using General.Services.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class ServicesOTO
    {
        public int ProductId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        public decimal Price { get; set; }
        //public string IconName { get; set; }
        public virtual CategoryDTO Category { get; set; }
    }
}
