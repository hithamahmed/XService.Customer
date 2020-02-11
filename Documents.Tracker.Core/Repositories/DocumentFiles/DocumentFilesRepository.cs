using Documents.Tracker.Core.DTO.Files;
using Documents.Tracker.Data;
using System;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.Repositories.DocumentFiles
{
    internal class DocumentFilesRepository : IDocumentFilesRepository
    {
        private readonly DocumentContext _db;
        public DocumentFilesRepository(DocumentContext db)
        {
            _db = db;
        }

        public Task<bool> AddEditRequiredServiceDocumentFile(ServiceDocumentFilesOTO serviceDocumentFiles)
        {
            throw new NotImplementedException();
        }
    }
}
