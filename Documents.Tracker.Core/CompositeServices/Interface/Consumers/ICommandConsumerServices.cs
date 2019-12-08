using Documents.Tracker.Core.DTO;
using General.App.Consumers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface ICommandConsumerServices
    {
        Task<int> AddOrEditConsumerByConsumer(ConsumerOTO conusmer);
        Task<int> SetEnableDisableConsumerByConusmerId(int conusmerId);
        public Task<int> AddOrEditConsumerAddressByConsumer(ConsumerAddressOTO Consumer);
        public Task<int> SetDefaultConsumerAddressByAddressId(int ConsumersAddressId);
    }
}
