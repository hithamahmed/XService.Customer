using General.Services.Core.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ManageServiceOTO
    {
        [Required]
        public ProductDTO Product { get; set; }

        public ICollection<ProductDocumentsRequirementsOTO> serviceDocumentsRequirements { get; set; }
        public ICollection<ProductIssuedDocumentsOTO> serviceIssuedDocuments { get; set; }

    }
}
