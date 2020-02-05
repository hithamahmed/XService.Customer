using Documents.Tracker.Core.DTO.Files;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    public interface IDocumentFilesRepository
    {
        Task<bool> AddEditRequiredServiceDocumentFile(ServiceDocumentFilesOTO serviceDocumentFiles);

    }
}
