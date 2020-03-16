using Documents.Tracker.Core.DTO.Files;
using ManageFiles.Commons;
using ManageFiles.Commons.DTO;
using ManageFiles.Core.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Services.Documents
{
    internal class DocumentsFileServices : IDocumentFilesService
    {
        private readonly IManageFilesCore filesRepository;
        private readonly IFilesCore filesCore;
        public DocumentsFileServices(IManageFilesCore _filesRepository
            , IFilesCore _filesCore)
        {
            filesCore = _filesCore;
            filesRepository = _filesRepository;
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
                        ReferenceTypeId = requiredDocumentFiles.DocumentId,
                        ExpiryDate = requiredDocumentFiles.ExpiryDate.Date
                    };
                    var attachedId = await filesRepository.AddEditDocumentFile(attachmentFiles);
                    if (attachedId > 0 && attachmentFiles.Id == 0)
                    {
                        if (requiredDocumentFiles.DocumentFile.Length > 0)
                        {
                            string securedFileName = await filesCore.UploadFile(requiredDocumentFiles.ConsumerKey, requiredDocumentFiles.DocumentFile);
                            if (!string.IsNullOrEmpty(securedFileName))
                            {
                                attachmentFiles.Id = attachedId;
                                attachmentFiles.SecureName = securedFileName;
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

        public async Task<AttachmentFileTypeDTO> GetSingleFileType(int FileTypeid)
        {
            try
            {
                return await filesRepository.GetSingleAttachmentsFileType(FileTypeid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<AttachmentFileTypeDTO>> GetDocumentFileType()
        {
            try
            {
                return  await filesRepository.GetAttachmentsFileType();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
