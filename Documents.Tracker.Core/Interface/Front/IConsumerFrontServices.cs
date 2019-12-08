using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IConsumerFrontServices
    {
        Task<ICollection<ConsumerProductsDTO>> GetListConsumerServicesByConsumer(int consumerId);
        Task<ConsumerProductsDTO> GetSingleConsumerServices(int ConsumerServiceId);
        Task<int> SaveConsumerService(ConsumerProductsDTO consumerService);
    }
}
