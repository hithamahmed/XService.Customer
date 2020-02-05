using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IQueryProductDocuments
    {
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
        Task<ICollection<ProductDocumentsRequirementsOTO>> GetRequiredDocumentsByServiceId(int productUKey);

    }
}
