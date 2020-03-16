using Documents.Tracker.Core.DTO;
using Documents.Tracker.Core.DTO.Consumers;
using General.App.Consumers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IQueryConsumersServices
    {
        Task<ICollection<ConsumerOTO>> GetAllConsumers();
        Task<ConsumerOTO> GetSingleConsumerByConusmerId(string conusmerId);
        Task<ICollection<ConsumerAddressOTO>> GetAllConsumerAddressesByConsumerId(string consumerId);
        Task<ConsumerAddressOTO> GetSingleConsumerAddressByAddressId(int ConsumersAddressId);
        Task<ConsumersProfileOTO> GetSingleConsumerWithAddressByConsumerId(string consumerId);

        Task<ICollection<ConsumerProductDocumentFileOTO>> GetConsumerProductAttachmentFiles(string consumerId,int ProductId);
        Task<ICollection<ConsumerAttachmentFileOTO>> GetConsumerAttachmentFiles(string consumerId);
    }
}
