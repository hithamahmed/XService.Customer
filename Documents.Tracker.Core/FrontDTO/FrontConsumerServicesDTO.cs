using System;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.FrontDTO
{
    public class FrontConsumerServicesDTO //: CoreBaseDTO
    {
        //public ConsumerOTO Consumer { get; set; }
        //public ServiceTaskDTO ServiceTask { get; set; }

        public string CategoryName { get; set; }

        public string ServiceCategoryName { get; set; }
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
