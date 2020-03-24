using Documents.Tracker.Core.DTO.DocumentsFiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Interface.DocumentsFiles
{
    public interface IQueryFileProviersSettingsService
    {
        Task<ICollection<FileProviderSettingesOTO>> GetFileSettings();
    }
}
