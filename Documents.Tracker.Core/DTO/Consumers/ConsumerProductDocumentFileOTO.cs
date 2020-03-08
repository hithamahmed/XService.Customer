using ManageFiles.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Tracker.Core.DTO.Consumers
{
    public class ConsumerProductDocumentFileOTO
    {
        public ConsumerProductDocumentFileOTO()
        {
            ProductDocuments = new ProductDocumentsRequirementsOTO();
            ConsumerFiles = new ConsumerAttachmentFileOTO();
        }
        public ProductDocumentsRequirementsOTO  ProductDocuments { get; set; }
        public ConsumerAttachmentFileOTO ConsumerFiles { get; set; }

       
    }
}
