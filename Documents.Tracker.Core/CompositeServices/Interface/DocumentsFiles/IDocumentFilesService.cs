using Documents.Tracker.Core.DTO.Files;
using ManageFiles.Commons.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IDocumentFilesService
    {
        Task<bool> UploadDocumentFile(ServiceDocumentFilesOTO requiredDocumentFiles);
        Task AddEditDocumentFileType(AttachmentFileTypeDTO attachmentFilesType);
    }
}
