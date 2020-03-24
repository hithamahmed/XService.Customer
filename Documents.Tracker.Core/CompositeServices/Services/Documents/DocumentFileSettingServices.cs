using Documents.Tracker.Core.CompositeServices.Interface.DocumentsFiles;
using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO.DocumentsFiles;
using ManageFiles.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Services.Documents
{
    internal class DocumentFileSettingServices : MapperCore, ICommandFilesSettingsService, IQueryFileProviersSettingsService
    {
        private readonly IFilesCore _filesCore;
        public DocumentFileSettingServices(
            IFilesCore filesCore)
        {
            _filesCore = filesCore;
        }
        public async Task ChangeFileProvider(int Id)
        {
            try
            {
                await _filesCore.SetDefaultFileProvider(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<FileProviderSettingesOTO>> GetFileSettings()
        {
            try
            {
               var settings = await _filesCore.GetAttachmentFilesSettinges();
               return Mapper.Map<ICollection<FileProviderSettingesOTO>>(settings);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
