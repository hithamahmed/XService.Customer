using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Documents.Tracker.Core.CompositeServices.Interface.DocumentsFiles;
using Documents.Tracker.Core.DTO.DocumentsFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Documents.Tracker.UI.Web.Pages.Admin
{
    public class SettingsModel : PageModel
    {
        private readonly ICommandFilesSettingsService  _commandFilesSettingsService;
        private readonly IQueryFileProviersSettingsService _fileProviersSettingsService;
        public ICollection<FileProviderSettingesOTO>  fileProviderSettinges { get; set; }
        public SettingsModel(IQueryFileProviersSettingsService fileProviersSettingsService,
            ICommandFilesSettingsService commandFilesSettingsService)
        {
            _commandFilesSettingsService = commandFilesSettingsService;
            _fileProviersSettingsService = fileProviersSettingsService;
        }
        public async Task OnGet()
        {
           fileProviderSettinges = await _fileProviersSettingsService.GetFileSettings();
        }


        public async Task<IActionResult> OnPost(int Id)
        {
            await _commandFilesSettingsService.ChangeFileProvider(Id);
            return Page();
        }
    }
}