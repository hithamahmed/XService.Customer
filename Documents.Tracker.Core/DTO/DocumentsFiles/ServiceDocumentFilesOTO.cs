using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO.Files
{
    public  class ServiceDocumentFilesOTO
    {
        [Required] public string ConsumerKey { get; set; }
        [Required] public int DocumentId { get; set; }
        [Required] public IFormFile DocumentFile { get; set; }
    }
}
