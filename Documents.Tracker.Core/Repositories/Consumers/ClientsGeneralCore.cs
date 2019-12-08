using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using General.App.Consumers.Core;
using General.App.Consumers.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.DocumentCore.Consumers
{
    internal class ClientsGeneralCore : MapperCore, IConsumersProfileCore
    {
        private IConsumers Clients { get; set; }
        private IConsumerAddress  consumerAddress { get; set; }
        private IGeneralCore countrycores { get; set; }
        public ClientsGeneralCore(IConsumers _clients,
            IConsumerAddress _consumerAddress
            , IGeneralCore _countrycores)
        {
            Clients = _clients;
            consumerAddress = _consumerAddress;
            countrycores = _countrycores;
        }
        public async Task<ICollection<APPConsumerDTO>> GetConsumers()
        {
            try
            {
                var _list = await Clients.GetAllConsumers();                 
                var mapps = Mapper.Map<ICollection<APPConsumerDTO>>(_list);
                foreach (var item in mapps)
                {
                    var addList = consumerAddress.GetAllConsumerAddresses(item.RefId).Result;
                    var addMapps = Mapper.Map<ICollection<AppConsumerAddressDTO>>(addList);
                    item.CounsumerAddresses = addMapps;
                }
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

        public async Task<ICollection<AppConsumerAddressDTO>> GetConsumerAddresses(int consumerId)
        {
            try
            {
                var _list = await consumerAddress.GetAllConsumerAddresses(consumerId);
                var mapps = Mapper.Map<ICollection<AppConsumerAddressDTO>>(_list);
                string _CountryName, _GovernmentName, _locationName  ;
                _CountryName = _GovernmentName = _locationName = "";

                foreach (var addr in mapps)
                {
                    var _Country = await countrycores.GetSingleCountry(addr.CountryId);
                    var _Government = await countrycores.GetSingleGovernment(addr.GovernmentId);
                    var _location = await countrycores.GetSingleLocation(addr.LocationAreaId);
                    
                    if (_Country != null)
                        _CountryName = _Country.Name;
                    
                    if (_Government != null)
                        _GovernmentName = _Government.Name;
                    
                    if (_location != null)
                        _locationName = _location.Name;

                    addr.FullLocation = $"{_CountryName}-{_GovernmentName}-{_locationName }";
                }
                return mapps;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddEditConsumerAddress(AppConsumerAddressDTO Consumer)
        {
            try
            {
                var mapps = Mapper.Map<ConsumerAddressDTO>(Consumer);
                return await consumerAddress.AddEditConsumerAddress(mapps);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SetConsumerAddressAsDefault(int ConsumersAddressId)
        {
            try
            {
                return await consumerAddress.SetConsumerAddressAsDefault(ConsumersAddressId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AppConsumerAddressDTO> GetConsumerAddressById(int ConsumersAddressId)
        {
            try
            {
                var _single = await consumerAddress.GetConsumerAddressById(ConsumersAddressId);
                var mapps = Mapper.Map<AppConsumerAddressDTO>(_single);
                return mapps;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
