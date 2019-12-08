using General.App.Consumers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
