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

        public async Task<int> AddEditServiceIssuedDocuments(ProductIssuedDocumentsOTO serviceDocumentsIssued)
        {
            try
            {
                var documentsIssued = Mapper.Map<DocIssued>(serviceDocumentsIssued);
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> EnableDisableServiceIssuedDocuments(int IssuedDocId)
        {
            try
            {
                var documentsIssued = _db.DocIssued.Find(IssuedDocId);
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

        public async Task<ProductIssuedDocumentsOTO> GetServiceIssuedDocument(int IssuedDocId)
        {
            try
            {
                var documentsIssued = await _db.DocIssued.FindAsync(IssuedDocId);
                return Mapper.Map<ProductIssuedDocumentsOTO>(documentsIssued);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<ProductIssuedDocumentsOTO>> GetIssuedDocumentsByServiceId(int productId)
        {
            try
            {
                var documentsIssued = await _db.DocIssued
                    //.Include(x=>x.Product)
                    .Where(x => x.ProductUKey == productId)
                    .ToListAsync();

                var x = Mapper.Map<ICollection<ProductIssuedDocumentsOTO>>(documentsIssued);
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
