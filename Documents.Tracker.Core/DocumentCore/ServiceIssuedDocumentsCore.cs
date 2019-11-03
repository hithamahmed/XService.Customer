using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using Documents.Tracker.Data;
using Documents.Tracking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    internal class ServiceIssuedDocumentsCore : MapperCore, IServiceIssuedDocumentsCore
    {
        //private readonly IMapper _mapper;
        private readonly DocumentContext _db;
        public ServiceIssuedDocumentsCore(DocumentContext db)//, IMapper mapper)
        {
            _db = db;
            //_mapper = mapper;
        }

        public async Task<int> AddEditServiceIssuedDocuments(ServiceIssuedDocumentsDTO serviceDocumentsIssued)
        {
            try
            {
                var documentsIssued = Mapper.Map<DocFinal>(serviceDocumentsIssued);
                if (serviceDocumentsIssued.RefId == 0)
                {
                    await _db.DocIssued.AddAsync(documentsIssued);
                }
                else
                {
                    _db.DocIssued.Update(documentsIssued);
                }

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = ex;
                throw error;
            }
        }

        public async Task<int> EnableDisableServiceIssuedDocuments(int ServiceId)
        {
            try
            {
                var documentsIssued = _db.DocIssued.Find(ServiceId);
                if (documentsIssued == null)
                {
                    return 0;
                }

                documentsIssued.IsDeleted = !documentsIssued.IsDeleted;
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ServiceIssuedDocumentsDTO> GetServiceIssuedDocument(int IssuedDocId)
        {
            try
            {
                var RequirementsDocs = await _db.DocIssued.FindAsync(IssuedDocId);
                return Mapper.Map<ServiceIssuedDocumentsDTO>(RequirementsDocs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<ServiceIssuedDocumentsDTO>> GetIssuedDocumentsByServiceId(int serviceId)
        {
            try
            {
                var RequirementsDocs = await _db.DocIssued.Where(x => x.ServiceId == serviceId).ToListAsync();
                return Mapper.Map<ICollection<ServiceIssuedDocumentsDTO>>(RequirementsDocs);
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
