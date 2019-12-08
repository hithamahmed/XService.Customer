using Documents.Tracker.Core.DTO;
using General.Services.Core.DTO;
using System;
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
        public Task<int> AddEditServiceIssuedDocuments(ProductIssuedDocumentsOTO serviceDocumentsIssued);

        /// <summary>
        /// Delete Issued Documents by id
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns></returns>
        public Task<int> EnableDisableServiceIssuedDocuments(int IssuedDocId);

        /// <summary>
        /// Get single Issued documents
        /// </summary>
        /// <param name="IssuedDocId"></param>
        /// <returns></returns>
        public Task<ProductIssuedDocumentsOTO> GetServiceIssuedDocument(int IssuedDocId);
        /// <summary>
        /// Get all Issued documents by service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        Task<ICollection<ProductIssuedDocumentsOTO>> GetIssuedDocumentsByServiceId(int productUKey);
    }
}
