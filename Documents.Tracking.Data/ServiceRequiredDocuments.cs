using AutoMapper;
using Documents.Tracking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Data
{
    public class ServiceRequiredDocuments
    {
        private readonly IMapper _mapper;
        private readonly DocumentContext _db;
        public ServiceRequiredDocuments(GeneralContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<int> AddEdit(ServiceDocumentsRequirementsDTO serviceDocumentsRequirementsDTO)
        {
            try
            {
                var documentsRequirements = _mapper.Map<DocRequirements>(serviceDocumentsRequirementsDTO);
                if (serviceDocumentsRequirementsDTO.RefId == 0)
                {
                    await _db.DocRequirements.AddAsync(documentsRequirements);
                }
                else
                {
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
    }
}
