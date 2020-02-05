using Documents.Tracker.Core.DTO;
using System.Threading.Tasks;
namespace Documents.Tracker.Core
{
    public interface ICommandProductDocuments
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


    }
}
