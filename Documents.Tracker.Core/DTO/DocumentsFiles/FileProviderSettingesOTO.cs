using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Documents.Tracker.Core.DTO.DocumentsFiles
{
    public class FileProviderSettingesOTO
    {
        public int Id { get; set; }
        [StringLength(100)] public string FileServerProvider { get; set; }
        [StringLength(100)] public string FolderServerPathBase { get; set; }
        public bool IsDefaultProvider { get; set; }
    }
}
