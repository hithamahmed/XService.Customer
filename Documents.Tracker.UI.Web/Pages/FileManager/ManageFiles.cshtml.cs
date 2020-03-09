using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Documents.Tracker.UI.Web.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Documents.Tracker.UI.Web.Pages.FileManager
{
    public class ManageFilesModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ManageFilesModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostDownload(string pathUri)
        {
            try
            {
                var root = _webHostEnvironment.WebRootPath;
                string path = Path.Combine(
                               _webHostEnvironment.ContentRootPath,
                               pathUri);

                if (System.IO.File.Exists(path))
                {
                    var memory = new MemoryStream();
                    memory = await FileExtension.GetDownLoadFile(path);
                    return File(memory, FileExtension.GetContentType(path), Path.GetFileName(path));
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }


    }
}