using Documents.Tracker.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IQueryProductDocumentServices
    {
        /// <summary>
        /// Get single Issued documents
        /// </summary>
        /// <param name="IssuedDocId"></param>
        /// <returns></returns>
        public Task<ProductIssuedDocumentsOTO> GetSingleProductIssuedDocument(int IssuedDocId);
        /// <summary>
        /// Get all Issued documents by service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        Task<ICollection<ProductIssuedDocumentsOTO>> GetIssuedDocuments(int productId);

        /// <summary>
        /// Get single required documents
        /// </summary>
        /// <param name="requiredDocsId"></param>
        /// <returns></returns>
        public Task<ProductDocumentsRequirementsOTO> GetSingleProductRequiredDocument(int requiredDocId);
        /// <summary>
        /// Get all required documents by service id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        Task<ICollection<ProductDocumentsRequirementsOTO>> GetRequiredDocuments(int productId);

    }
}
