using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO.Files
{
    public class ServiceDocumentFilesOTO
    {
        [Required] public string ConsumerKey { get; set; }
        [Required] public int DocumentId { get; set; }
        [Required] public IFormFile DocumentFile { get; set; }
    }
}
