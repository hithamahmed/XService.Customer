using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.DTO
{
    public class ManageServiceIssueDocumentsOTO
    {
        public int serviceRefId { get; set; }
        public ICollection<ProductIssuedDocumentsOTO> serviceIssueDocumentsDTO { get; set; }
    }
}
