using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Documents.Tracker.Core.DTO
{
    public class ConsumersProfileOTO
    {
        public ConsumersProfileOTO()
        {
            AppConsumerAddresses = new Collection<ConsumerAddressOTO>();
            Consumer = new ConsumerOTO();
        }
        public ConsumerOTO Consumer { get; set; }
        public ICollection<ConsumerAddressOTO> AppConsumerAddresses { get; set; }

    }
}
