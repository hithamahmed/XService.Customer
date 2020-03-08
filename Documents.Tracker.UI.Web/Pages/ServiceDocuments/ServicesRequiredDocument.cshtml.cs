using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.Pages.ServiceDocuments
{
    public class ServicesRequiredDocumentsModel : PageModel
    {
        private readonly IQueryProductDocumentServices serviceDocuments;
        private readonly ICommandProductDocuments commandProductDocuments;
        public ManageServiceRequiredDocumentsOTO serviceRequiredDocuments { get; set; }


        public ServicesRequiredDocumentsModel(
                        IQueryProductDocumentServices _serviceIssuedDocuments,
                        ICommandProductDocuments _commandProductDocuments)
        {
            serviceDocuments = _serviceIssuedDocuments;
            commandProductDocuments = _commandProductDocuments;
        }

        public async Task<IActionResult> OnGet(int serviceRefId)
        {
            var requiredDocs = await serviceDocuments.GetRequiredDocuments(serviceRefId);

            serviceRequiredDocuments = new ManageServiceRequiredDocumentsOTO();
            serviceRequiredDocuments.serviceRefId = serviceRefId;
            serviceRequiredDocuments.ProductDocumentsRequirements = requiredDocs;
            return Page();
        }

        public async Task<IActionResult> OnGetAddEditServiceRequiredDocsAsync(int Serviceid, int RefId)
        {
            try
            {
                ProductDocumentsRequirementsOTO documentsRequirements = new ProductDocumentsRequirementsOTO
                {
                    ProductUKey = Serviceid
                };

                if (RefId > 0)
                {
                    documentsRequirements = await serviceDocuments.GetSingleProductRequiredDocument(RefId);
                }
                return Partial("_AddEditRequiredDocs", documentsRequirements);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostSaveServiceRequiredDocs(ProductDocumentsRequirementsOTO service)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = commandProductDocuments.AddEditServiceRequiredDocuments(service).Result;
                return RedirectToPage("ServicesRequiredDocument", new { serviceRefId = service.ProductUKey });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostDisableServiceRequiredDocs(int RefId, int serviceid)
        {
            try
            {
                int i = commandProductDocuments.EnableDisableServiceRequiredDocuments(RefId).Result;
                return RedirectToPage("ServicesRequiredDocument", new { serviceRefId = serviceid });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
    }
}