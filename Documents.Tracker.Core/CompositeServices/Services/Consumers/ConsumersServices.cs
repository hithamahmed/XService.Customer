using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using General.App.Consumers.Core;
using General.App.Consumers.Core.DTO;

namespace Documents.Tracker.Core
{
    internal class ConsumersServices : MapperCore, IQueryConsumersServices, ICommandConsumerServices
    {
        //private readonly IConsumersProfileCore consumersProfileCore;
        private readonly IConsumers consumersProfileCore;
        private readonly IConsumerAddress consumersAddressCore;
        public ConsumersServices(IConsumers _consumersProfileCore
            , IConsumerAddress _consumersAddressCore)
        {
            consumersProfileCore = _consumersProfileCore;
            consumersAddressCore = _consumersAddressCore;
        }


        public async Task<ICollection<ConsumerAddressOTO>> GetAllConsumerAddressesByConsumerId(int consumerId)
        {
            try
            {
                var x = await consumersAddressCore.GetAllConsumerAddresses(consumerId);
                return Mapper.Map<ICollection<ConsumerAddressOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ICollection<ConsumerOTO>> GetAllConsumers()
        {
            try
            {
                var x = await consumersProfileCore.GetAllConsumers();
                return Mapper.Map<ICollection<ConsumerOTO>>(x); 
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ConsumerAddressOTO> GetSingleConsumerAddressByAddressId(int ConsumersAddressId)
        {
            try
            {
                var x = await consumersAddressCore.GetConsumerAddressById(ConsumersAddressId);
                return Mapper.Map<ConsumerAddressOTO>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ConsumerOTO> GetSingleConsumerByConusmerId(int conusmerId)
        {
            try
            {
                var x = await consumersProfileCore.GetConsumerById(conusmerId);
                return Mapper.Map<ConsumerOTO>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ConsumersProfileOTO> GetSingleConsumerWithAddressByConsumerId(int consumerId)
        {
            ConsumersProfileOTO manageAppConsumerDTO = new ConsumersProfileOTO();
            try
            {
                var x = await GetSingleConsumerByConusmerId(consumerId);
                manageAppConsumerDTO.Consumer = Mapper.Map<ConsumerOTO>(x);

                var ConsumAddresses = await GetAllConsumerAddressesByConsumerId(consumerId);
                   
                manageAppConsumerDTO.AppConsumerAddresses = ConsumAddresses;
                return manageAppConsumerDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<int> SetDefaultConsumerAddressByAddressId(int ConsumersAddressId)
        {
            try
            {
                return await consumersAddressCore.SetConsumerAddressAsDefault(ConsumersAddressId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> SetEnableDisableConsumerByConusmerId(int conusmerId)
        {
            try
            {
                return await consumersProfileCore.EnableDisableConsumer(conusmerId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> AddOrEditConsumerAddressByConsumer(ConsumerAddressOTO Consumer)
        {
            try
            {
                var x = Mapper.Map<ConsumerAddressDTO>(Consumer);
                return await consumersAddressCore.AddEditConsumerAddress(x);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> AddOrEditConsumerByConsumer(ConsumerOTO conusmer)
        {
            try
            {
                var x = Mapper.Map<ConsumerDTO>(conusmer);
                return await consumersProfileCore.AddEditConsumer(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
