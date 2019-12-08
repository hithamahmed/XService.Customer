using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using Documents.Tracker.Data;
using Documents.Tracking.Data.Entities;
using General.Services.Core.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.DocumentCore.Consumers
{
    internal class ConsumerServicesCore : MapperCore, IConsumersServicesCore
    {
        private readonly DocumentContext _db;
        public ConsumerServicesCore(DocumentContext db)//, IMapper mapper)
        {
            _db = db;
        }
        public async Task<ICollection<ConsumerProductsDTO>> GetListConsumerServicesByConsumer(int consumerId)
        {
            try
            {
                var _list = await _db.ConsumerServices
                    .Include(x => x.Product).ThenInclude(x=>x.Category)
                    .Include(x => x.CurrentServiceStatus)
                    .Where(x => x.ConsumerId == consumerId)
                    .ToListAsync();

                var mapps = Mapper.Map<ICollection<ConsumerProductsDTO>>(_list);

                return mapps;
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
                var _single = await _db.ConsumerServices
                    .Include(x => x.Product)
                    .Include(x => x.CurrentServiceStatus)
                    .Where(x=>x.Id == ConsumerServiceId)
                    .FirstOrDefaultAsync();
                var mapps = Mapper.Map<ConsumerProductsDTO>(_single);
                return mapps;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveConsumerService(ConsumerProductsDTO consumerServices)
        {
            try
            {
                if (consumerServices == null)
                    return -1;

                var _mapper = Mapper.Map<ConsumerServices>(consumerServices);
                await _db.ConsumerServices.AddAsync(_mapper);
                var i = await _db.SaveChangesAsync();
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
