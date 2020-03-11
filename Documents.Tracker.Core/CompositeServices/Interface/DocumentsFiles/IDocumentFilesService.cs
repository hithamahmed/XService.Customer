using Documents.Tracker.Core.DTO.Files;
using ManageFiles.Commons.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IDocumentFilesService
    {
        Task<bool> UploadDocumentFile(ServiceDocumentFilesOTO requiredDocumentFiles);
        Task AddEditDocumentFileType(AttachmentFileTypeDTO attachmentFilesType);
        Task<AttachmentFileTypeDTO> GetSingleFileType(int FileTypeid);
        Task<ICollection<AttachmentFileTypeDTO>> GetDocumentFileType();
    }
}
