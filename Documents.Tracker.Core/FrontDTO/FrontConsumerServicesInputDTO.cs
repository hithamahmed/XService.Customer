using System;

namespace Documents.Tracker.Core.FrontDTO
{
    public class FrontConsumerServicesInputDTO
    {
        public int ConsumerId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public int CurrentServiceStatus { get; set; }

    }
}
