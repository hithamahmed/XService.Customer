using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
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
        public Task<int> AddEditServiceRequiredDocuments(ProductDocumentsRequirementsOTO serviceDocumentsRequirements);

        /// <summary>
        /// Delete Required Documents by id
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        public Task<int> EnableDisableServiceRequiredDocuments(int requiredDocId);

        /// <summary>
        /// Get single required documents
        /// </summary>
        /// <param name="requiredDocsId"></param>
        /// <returns></returns>
        public Task<ProductDocumentsRequirementsOTO> GetServiceRequiredDocument(int requiredDocId);
        /// <summary>
        /// Get all required documents by service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public Task<ICollection<ProductDocumentsRequirementsOTO>> GetRequiredDocumentsByServiceId(int productId);
    }
}
