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
    internal class ServiceRequiredDocumentsCore : MapperCore, IServiceRequiredDocumentsCore
    {
        //private readonly IMapper _mapper;

        private readonly DocumentContext _db;
        public ServiceRequiredDocumentsCore(DocumentContext db)//, IMapper mapper)
        {
            _db = db;
            //_mapper = mapper;
        }

        public async Task<int> AddEditServiceRequiredDocuments(ProductDocumentsRequirementsOTO serviceDocumentsRequirements)
        {
            try
            {

                var documentsRequirements = Mapper.Map<DocRequirements>(serviceDocumentsRequirements);
                if (serviceDocumentsRequirements.RefId == 0)
                {
                    await _db.DocRequirements.AddAsync(documentsRequirements);
                }
                else
                {
                    //documentsRequirements.ModifiedAt = DateTime.UtcNow.AddHours(3);
                    _db.DocRequirements.Update(documentsRequirements);
                }

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = ex;
                throw error;
            }
        }

        public async Task<int> EnableDisableServiceRequiredDocuments(int requiredDocId)
        {
            try
            {
                var documentsRequirements = _db.DocRequirements.Find(requiredDocId);
                if (documentsRequirements == null)
                {
                    return 0;
                }

                documentsRequirements.IsDeleted = !documentsRequirements.IsDeleted;
                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductDocumentsRequirementsOTO> GetServiceRequiredDocument(int requiredDocId)
        {
            try
            {
                var RequirementsDocs = await _db.DocRequirements.FindAsync(requiredDocId);
                return Mapper.Map<ProductDocumentsRequirementsOTO>(RequirementsDocs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<ProductDocumentsRequirementsOTO>> GetRequiredDocuments(int productId)
        {
            try
            {
                var RequirementsDocs = await _db.DocRequirements.Where(x => x.ProductUKey == productId).ToListAsync();
                return Mapper.Map<ICollection<ProductDocumentsRequirementsOTO>>(RequirementsDocs);
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
