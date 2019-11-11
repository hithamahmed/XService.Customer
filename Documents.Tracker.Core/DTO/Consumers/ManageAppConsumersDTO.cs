using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class ManageAppConsumersDTO
    {
        public APPConsumerDTO Consumer { get; set; }
        public ICollection<AppConsumerAddressDTO> AppConsumerAddresses { get; set; }

    }
}
