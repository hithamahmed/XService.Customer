using Documents.Tracker.Core.DTO.Files;
using ManageFiles.Commons.DTO;
using ManageFiles.Commons.Interface;
using ManageFiles.Core.Interface;
using ManageFiles.Core.Services;
using ManageFiles.Models.DTO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Services.Documents
{
    internal class DocumentsFileServices : IDocumentFilesService
    {
        private readonly IManageFilesCore filesRepository;
        private IHandleFilesCore handleFiles { get; set; }
        private readonly IFilesCore filesCore;
        public DocumentsFileServices(IManageFilesCore _filesRepository
            ,IFilesCore _filesCore
            //, IHandleFilesCore _handleFiles
            )
        {
            filesCore = _filesCore;
            filesRepository = _filesRepository;
            //handleFiles = _handleFiles;
        }
        public async Task<bool> UploadDocumentFile(ServiceDocumentFilesOTO requiredDocumentFiles)
        {
            try
            {
                if (requiredDocumentFiles.DocumentFile.Length > 0)
                {
                    AttachmentFilesDTO attachmentFiles = new AttachmentFilesDTO()
                    {
                        Id = 0,
                        FileName = requiredDocumentFiles.DocumentFile.FileName,
                        IsValid = true,
                        ReferenceId = requiredDocumentFiles.ConsumerKey,
                        ReferenceTypeId = requiredDocumentFiles.DocumentId
                    };
                    var attachedId = await filesRepository.AddEditDocumentFile(attachmentFiles);
                    if (attachedId > 0 && attachmentFiles.Id == 0)
                    {
                        if (requiredDocumentFiles.DocumentFile.Length > 0)
                        {
                            //handleFiles.UploadFile(requiredDocumentFiles.DocumentFile);
                            string securedFileName = await filesCore.UploadFile(requiredDocumentFiles.ConsumerKey, requiredDocumentFiles.DocumentFile);
                            if (!string.IsNullOrEmpty(securedFileName))
                            {
                                attachmentFiles.Id = attachedId;
                                attachmentFiles.SecureFileName = securedFileName;
                                await filesRepository.UpdateDocumentFile(attachmentFiles);
                            }

                            return !string.IsNullOrEmpty(securedFileName);
                        }
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddEditDocumentFileType(AttachmentFileTypeDTO attachmentFilesType)
        {
            try
            {
                await filesRepository.AddEditAttachmentFileType(attachmentFilesType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
