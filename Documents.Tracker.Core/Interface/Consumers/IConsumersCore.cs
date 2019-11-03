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
    }
}
