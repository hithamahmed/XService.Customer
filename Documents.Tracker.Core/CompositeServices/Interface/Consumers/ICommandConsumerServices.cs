using Documents.Tracker.Core.DTO;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface ICommandConsumerServices
    {
        //Task<int> AddOrEditConsumerByConsumer(ConsumerOTO conusmer);
        //Task<int> SetEnableDisableConsumerByConusmerId(int conusmerId);
        Task<int> EditConsumerProfile(ConsumerOTO conusmer);

        public Task<int> AddOrEditConsumerAddressByConsumer(ConsumerAddressOTO Consumer);
        public Task<int> SetDefaultConsumerAddressByAddressId(int ConsumersAddressId);

        Task<bool> SoftDeleteConsumerDocumentFile(int Id);

    }
}
