using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.Pages.ServiceDocuments
{
    public class ServicesIssuedDocumentsModel : PageModel
    {
        private readonly IQueryProductDocumentServices queryServiceDocuments;
        private readonly ICommandProductDocuments commandProductDocuments;
        public ManageServiceIssueDocumentsOTO serviceIssueDocumentsOTO { get; set; }

        public ServicesIssuedDocumentsModel(
            IQueryProductDocumentServices _queryserviceDocuments,
            ICommandProductDocuments _commandProductDocuments)
        {
            queryServiceDocuments = _queryserviceDocuments;
            commandProductDocuments = _commandProductDocuments;
        }

        public async Task<IActionResult> OnGet(int serviceRefId)
        {
            var issueddocs = await queryServiceDocuments.GetIssuedDocuments(serviceRefId);
            serviceIssueDocumentsOTO = new ManageServiceIssueDocumentsOTO();
            serviceIssueDocumentsOTO.serviceRefId = serviceRefId;
            serviceIssueDocumentsOTO.serviceIssueDocumentsDTO = issueddocs;

            return Page();
        }

        public async Task<IActionResult> OnGetAddEditServiceIssuedDocsAsync(int Serviceid, int RefId)
        {
            try
            {
                ProductIssuedDocumentsOTO ProductIssuedDocuments = new ProductIssuedDocumentsOTO
                {
                    ProductUKey = Serviceid
                };

                if (RefId > 0)
                {
                    ProductIssuedDocuments = await queryServiceDocuments.GetSingleProductIssuedDocument(RefId);
                }
                return Partial("_AddEditIssuedDocs", ProductIssuedDocuments);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostSaveServiceIssuedDocs(ProductIssuedDocumentsOTO service)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = commandProductDocuments.AddEditServiceIssuedDocuments(service).Result;
                return RedirectToPage("ServicesIssuedDocuments", new { serviceRefId = service.ProductUKey });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostDisableServiceIssuedDocs(int RefId, int serviceid)
        {
            try
            {
                int i = commandProductDocuments.EnableDisableServiceIssuedDocuments(RefId).Result;
                return RedirectToPage("ServicesIssuedDocuments", new { serviceRefId = serviceid });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }

    }
}