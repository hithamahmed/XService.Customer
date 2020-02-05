using System.Collections.Generic;

namespace Documents.Tracker.Core.DTO
{
    public class ManageServiceIssueDocumentsOTO
    {
        public int serviceRefId { get; set; }
        public ICollection<ProductIssuedDocumentsOTO> serviceIssueDocumentsDTO { get; set; }
    }
}
