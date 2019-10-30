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

namespace Documents.Tracker.UI.Web.Pages.ServiceDocuments
{
    public class ServicesIssuedDocumentsModel : PageModel
    {
        private IServiceIssuedDocumentsCore serviceIssuedDocuments { get; set; }
        public IServicesCategory servicesCategory { get; set; }
        public IMapper mapper { get; set; }
        public ManageServiceDTO manageServiceDTO { get; set; }

        public ServicesIssuedDocumentsModel(IServiceIssuedDocumentsCore _serviceIssuedDocuments,
            IServicesCategory _servicesCategory, IMapper _mapper)
        {
            serviceIssuedDocuments = _serviceIssuedDocuments;
            servicesCategory = _servicesCategory;
            mapper = _mapper;
        }

        public async Task<IActionResult> OnGet(int serviceRefId)
        {
            var servicecategory = await servicesCategory.GetServiceCategoryById(serviceRefId);
            var serviceDocumentsRequirements = await serviceIssuedDocuments.GetIssuedDocumentsByServiceId(serviceRefId);

            manageServiceDTO = new ManageServiceDTO();
            manageServiceDTO.ServiceCategory = servicecategory;
            manageServiceDTO.serviceIssuedDocuments = serviceDocumentsRequirements;
            return Page();
        }

        public async Task<IActionResult> OnGetAddEditServiceIssuedDocsAsync(int Serviceid, int RefId)
        {
            try
            {
                ServiceIssuedDocumentsDTO documentsRequirements = new ServiceIssuedDocumentsDTO
                {
                    ServiceId = Serviceid
                };

                if (RefId > 0)
                {
                    documentsRequirements = await serviceIssuedDocuments.GetServiceIssuedDocument(RefId);
                }
                return Partial("_AddEditIssuedDocs", documentsRequirements);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostSaveServiceIssuedDocs(ServiceIssuedDocumentsDTO service)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = serviceIssuedDocuments.AddEditServiceIssuedDocuments(service).Result;
                return RedirectToPage("ServicesIssuedDocuments", new { serviceRefId = service.ServiceId });
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
                int i = serviceIssuedDocuments.EnableDisableServiceIssuedDocuments(RefId).Result;
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