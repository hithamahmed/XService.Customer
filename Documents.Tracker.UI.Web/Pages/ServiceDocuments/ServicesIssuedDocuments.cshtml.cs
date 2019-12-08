using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using General.Services.Core;
using General.Services.Core.DTO;
using General.Services.Core.Interface;
using Documents.Tracker.UI.Web.DTO;

namespace Documents.Tracker.UI.Web.Pages.ServiceDocuments
{
    public class ServicesIssuedDocumentsModel : PageModel
    {
        private readonly IQueryProductDocuments queryServiceDocuments;
        private readonly ICommandProductDocuments commandProductDocuments;
       // public IProducts servicesCategory { get; set; }
        //public IMapper mapper { get; set; }
        public ManageServiceIssueDocumentsOTO serviceIssueDocumentsOTO { get; set; }

        public ServicesIssuedDocumentsModel(
            IQueryProductDocuments _queryserviceDocuments,
            ICommandProductDocuments _commandProductDocuments)
            //IProducts _servicesCategory)
        {
            queryServiceDocuments = _queryserviceDocuments;
            commandProductDocuments = _commandProductDocuments;
            //servicesCategory = _servicesCategory;
            //mapper = _mapper;
        }

        public async Task<IActionResult> OnGet(int serviceRefId)
        {
            //var servicecategory = await queryServiceDocuments.GetProductByUKey(serviceRefId);
            var issueddocs = await queryServiceDocuments.GetIssuedDocumentsByServiceId(serviceRefId);
            serviceIssueDocumentsOTO = new ManageServiceIssueDocumentsOTO();
            serviceIssueDocumentsOTO.serviceRefId = serviceRefId;
            serviceIssueDocumentsOTO.serviceIssueDocumentsDTO = issueddocs;

            return Page();
        }

        public async Task<IActionResult> OnGetAddEditServiceIssuedDocsAsync(int Serviceid,int RefId)
        {
            try
            {
                ProductIssuedDocumentsOTO ProductIssuedDocuments = new ProductIssuedDocumentsOTO {
                    ProductUKey = Serviceid
                };

                if (RefId > 0)
                {
                    ProductIssuedDocuments = await queryServiceDocuments.GetServiceIssuedDocument(RefId);
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