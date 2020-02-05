using System.Collections.Generic;

namespace Documents.Tracker.Core.DTO
{
    public class ManageServiceRequiredDocumentsOTO
    {
        public int serviceRefId { get; set; }
        public ICollection<ProductDocumentsRequirementsOTO> ProductDocumentsRequirements { get; set; }


    }
}
