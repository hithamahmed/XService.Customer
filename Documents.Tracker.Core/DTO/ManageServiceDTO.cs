using General.Services.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class ManageServiceDTO
    {
        [Required]
        public ServiceCategoryDTO ServiceCategory { get; set; }

        public ICollection<ServiceDocumentsRequirementsDTO> serviceDocumentsRequirements {get;set;}
        public ICollection<ServiceIssuedDocumentsDTO> serviceIssuedDocuments { get; set; }

    }
}
