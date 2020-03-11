namespace Documents.Tracker.Core.DTO.Consumers
{
    public class ConsumerProductDocumentFileOTO
    {
        public ConsumerProductDocumentFileOTO()
        {
            ProductDocuments = new ProductDocumentsRequirementsOTO();
            ConsumerFiles = new ConsumerAttachmentFileOTO();
        }
        public ProductDocumentsRequirementsOTO ProductDocuments { get; set; }
        public ConsumerAttachmentFileOTO ConsumerFiles { get; set; }
        public string FilePathUrl { get; set; }

    }
}
