using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IServiceRequiredDocumentsCore
    {
        /// <summary>
        /// Add or edit exists Required Documents
        /// </summary>
        /// <param name="serviceDocumentsRequirements"></param>
        /// <returns></returns>
        public Task<int> AddEditServiceRequiredDocuments(ServiceDocumentsRequirementsDTO serviceDocumentsRequirements);

        /// <summary>
        /// Delete Required Documents by id
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        public Task<int> EnableDisableServiceRequiredDocuments(int ServiceId);

        /// <summary>
        /// Get single required documents
        /// </summary>
        /// <param name="requiredDocsId"></param>
        /// <returns></returns>
        public Task<ServiceDocumentsRequirementsDTO> GetServiceRequiredDocument(int requiredDocId);
        /// <summary>
        /// Get all required documents by service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        Task<ICollection<ServiceDocumentsRequirementsDTO>> GetRequiredDocumentsByServiceId(int serviceId);
    }
}
