using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IConsumersServicesCore
    {
        //Task<ICollection<ICollection<APPConsumerServicesDTO>>> GetAllConsumerServices();
        Task<ICollection<ConsumerProductsDTO>> GetListConsumerServicesByConsumer(int consumerId);
        Task<ConsumerProductsDTO> GetSingleConsumerServices(int ConsumerServiceId);
        //Task<int> SetServiceStatus(APPConsumerServicesDTO consumerServices);
        Task<int> SaveConsumerService(ConsumerProductsDTO consumerServices);
    }
}
