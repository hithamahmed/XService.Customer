using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Tracker.Core.DTO
{
    public class ConsumerAttachmentFileOTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
        public int DocumentTypeId { get; set; }
        public bool IsValid { get; set; }
        public string ConsumerId { get; set; }
        public string SecureName { get; set; }
    }
}
