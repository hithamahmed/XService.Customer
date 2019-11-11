using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IConsumersCore
    {
        Task<ICollection<APPConsumerDTO>> GetConsumers();

        Task<int> AddEditConsumer(APPConsumerDTO conusmer);

        Task<int> EnableDisableConsumer(int conusmerId);

        Task<APPConsumerDTO> GetSingleConsumer(int conusmerId);




        /// <summary>
        /// Get List Of Consumer Addresses
        /// </summary>
        /// <param name="consumerId"></param>
        /// <returns></returns>
        public Task<ICollection<AppConsumerAddressDTO>> GetConsumerAddresses(int consumerId);
        /// <summary>
        /// Add or Edit exists address
        /// </summary>
        /// <param name="Consumer"></param>
        /// <returns></returns>
        public Task<int> AddEditConsumerAddress(AppConsumerAddressDTO Consumer);
        /// <summary>
        /// Set address as default
        /// </summary>
        /// <param name="ConsumersAddressId"></param>
        /// <returns></returns>
        public Task<int> SetConsumerAddressAsDefault(int ConsumersAddressId);
        /// <summary>
        /// Get single consumer address
        /// </summary>
        /// <param name="ConsumersAddressId"></param>
        /// <returns></returns>
        public Task<AppConsumerAddressDTO> GetConsumerAddressById(int ConsumersAddressId);


    }
}
