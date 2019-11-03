using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using General.App.Consumers.Core;
using General.App.Consumers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.DocumentCore.Consumers
{
    internal class ClientsGeneralCore : MapperCore, IConsumersCore
    {
        private IConsumers Clients { get; set; }
        public ClientsGeneralCore(IConsumers _clients)
        {
            Clients = _clients;
        }
        public async Task<ICollection<APPConsumerDTO>> GetConsumers()
        {
            try
            {
                var _list = await Clients.GetAllConsumers();
                var mapps = Mapper.Map<ICollection<APPConsumerDTO>>(_list);
                return mapps;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddEditConsumer(APPConsumerDTO conusmer)
        {
            try
            {
                var mapps = Mapper.Map<ConsumerDTO>(conusmer);
                return await Clients.AddEditConsumer(mapps);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> EnableDisableConsumer(int conusmerId)
        {
            try
            {
                return await Clients.EnableDisableConsumer(conusmerId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<APPConsumerDTO> GetSingleConsumer(int conusmerId)
        {
            try
            {
                var _single = await Clients.GetConsumerById(conusmerId);
                var mapps = Mapper.Map<APPConsumerDTO>(_single);
                return mapps;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
