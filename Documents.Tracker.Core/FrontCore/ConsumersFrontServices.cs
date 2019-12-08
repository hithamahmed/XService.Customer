using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using General.App.Consumers.Core;

namespace Documents.Tracker.Core.FrontCore
{
    internal class ConsumersFrontServices : MapperCore, IConsumerFrontServices
    {
        private IConsumersServicesCore consumersServices { get; set; }
        public ConsumersFrontServices(IConsumersServicesCore _consumersServices)
        {
            consumersServices = _consumersServices;
        }
        public async Task<ICollection<ConsumerProductsDTO>> GetListConsumerServicesByConsumer(int consumerId)
        {
            try
            {
                var _list = await consumersServices.GetListConsumerServicesByConsumer(consumerId);
                return _list;
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        public async Task<ConsumerProductsDTO> GetSingleConsumerServices(int ConsumerServiceId)
        {
            try
            {
                var _list = await consumersServices.GetSingleConsumerServices(ConsumerServiceId);
                return _list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveConsumerService(ConsumerProductsDTO consumerService)
        {
            try
            {
                var i = await consumersServices.SaveConsumerService(consumerService);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
