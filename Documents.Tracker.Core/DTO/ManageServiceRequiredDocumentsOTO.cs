using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.DTO
{
    public class ManageServiceRequiredDocumentsOTO
    {
        public int serviceRefId { get; set; }
        public ICollection<ProductDocumentsRequirementsOTO> ProductDocumentsRequirements { get; set; }


    }
}
