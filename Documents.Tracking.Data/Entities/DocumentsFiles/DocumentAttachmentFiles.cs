using ApplicationCore.Interfaces;
using ManageFiles.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Tracker.Data.Entities.DocumentsFiles
{
    internal class DocumentAttachmentFiles : AttachmentFiles
    {
        public override string ReferenceId { get; set; }
        public int ConsumerId { get; set; }
    }
    //public  partial class DocumentAttachmentFiles  : IAuditable { }
}
