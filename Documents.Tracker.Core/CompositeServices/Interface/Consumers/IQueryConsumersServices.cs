using Documents.Tracker.Core.DTO;
using General.App.Consumers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IQueryConsumersServices
    {
        Task<ICollection<ConsumerOTO>> GetAllConsumers();
        Task<ConsumerOTO> GetSingleConsumerByConusmerId(int conusmerId);
        Task<ICollection<ConsumerAddressOTO>> GetAllConsumerAddressesByConsumerId(int consumerId);
        Task<ConsumerAddressOTO> GetSingleConsumerAddressByAddressId(int ConsumersAddressId);
        Task<ConsumersProfileOTO> GetSingleConsumerWithAddressByConsumerId(int consumerId);

    }
}
