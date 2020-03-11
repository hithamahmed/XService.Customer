using Documents.Tracker.Core;
using ManageFiles.Commons.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.Pages.GeneralPages.DocumentTypes
{
    public class DocumentTypesModel : PageModel
    {
        private readonly IDocumentFilesService _documentFilesService;
        public ICollection<AttachmentFileTypeDTO> AttachmentFileTypes { get; set; }
        public DocumentTypesModel(IDocumentFilesService documentFilesService)
        {
            _documentFilesService = documentFilesService;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                AttachmentFileTypes = await _documentFilesService.GetDocumentFileType();
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> OnGetAddEditFileType(int id)
        {
            try
            {
                AttachmentFileTypeDTO attachmentFileType = new AttachmentFileTypeDTO();
                if (id > 0)
                {
                    attachmentFileType = await _documentFilesService.GetSingleFileType(id);
                }
                return Partial("_AddEditFileType", attachmentFileType);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> OnPostSaveAttachmentFileType(AttachmentFileTypeDTO attachmentFileType)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }

            await _documentFilesService.AddEditDocumentFileType(attachmentFileType);
            return RedirectToPage();
        }
    }
}