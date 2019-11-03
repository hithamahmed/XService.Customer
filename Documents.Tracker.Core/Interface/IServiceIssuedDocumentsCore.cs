using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IServiceIssuedDocumentsCore
    {
        /// <summary>
        /// Add or edit exists Issued Documents
        /// </summary>
        /// <param name="serviceDocumentsIssued"></param>
        /// <returns></returns>
        public Task<int> AddEditServiceIssuedDocuments(ServiceIssuedDocumentsDTO serviceDocumentsIssued);

        /// <summary>
        /// Delete Issued Documents by id
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        public Task<int> EnableDisableServiceIssuedDocuments(int ServiceId);

        /// <summary>
        /// Get single Issued documents
        /// </summary>
        /// <param name="IssuedDocId"></param>
        /// <returns></returns>
        public Task<ServiceIssuedDocumentsDTO> GetServiceIssuedDocument(int IssuedDocId);
        /// <summary>
        /// Get all Issued documents by service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        Task<ICollection<ServiceIssuedDocumentsDTO>> GetIssuedDocumentsByServiceId(int serviceId);
    }
}
