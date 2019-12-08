using AutoMapper;
using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.FrontDTO
{
    public class FrontConsumerServicesDTO //: CoreBaseDTO
    {
        //public ConsumerOTO Consumer { get; set; }
        //public ServiceTaskDTO ServiceTask { get; set; }
 
        public string CategoryName { get; set; }
 
        public string ServiceCategoryName { get;set;}
        //public int ConsumerId { get; set; }
        //public int ServiceId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } 

        [DataType(DataType.Date)]
        public DateTime? FinishedDate { get; set; }

        //public int CurrentServiceStatusId { get; set; }
        public string DocStatusName { get; set; }
    }
}
