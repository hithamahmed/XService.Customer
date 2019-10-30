using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using General.Services.Core;
using General.Services.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Documents.Tracker.UI.Web.Pages.ServiceDocuments
{
    public class ServicesRequiredDocumentsModel : PageModel
    {
        private IServiceRequiredDocumentsCore serviceDocuments { get; set; }
        public IServicesCategory servicesCategory { get; set; }
        public IMapper mapper { get; set; }
        public ManageServiceDTO manageServiceDTO { get; set; }

        public ServicesRequiredDocumentsModel(IServiceRequiredDocumentsCore _serviceDocuments,
            IServicesCategory _servicesCategory, IMapper _mapper)
        {
            serviceDocuments = _serviceDocuments;
            servicesCategory = _servicesCategory;
            mapper = _mapper;
        }

        public async Task<IActionResult> OnGet(int serviceRefId)
        {
            var servicecategory = await servicesCategory.GetServiceCategoryById(serviceRefId);
            var serviceDocumentsRequirements = await serviceDocuments.GetRequiredDocumentsByServiceId(serviceRefId);

            manageServiceDTO = new ManageServiceDTO();
            manageServiceDTO.ServiceCategory = servicecategory;
            manageServiceDTO.serviceDocumentsRequirements = serviceDocumentsRequirements;
            return Page();
        }

        public async Task<IActionResult> OnGetAddEditServiceRequiredDocsAsync(int Serviceid, int RefId)
        {
            try
            {
                ServiceDocumentsRequirementsDTO documentsRequirements = new ServiceDocumentsRequirementsDTO
                {
                    ServiceId = Serviceid
                };

                if (RefId > 0)
                {
                    documentsRequirements = await serviceDocuments.GetServiceRequiredDocument(RefId);
                }
                return Partial("_AddEditRequiredDocs", documentsRequirements);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ex", ex.Message);
                return RedirectToPage();
            }
        }
        public IActionResult OnPostSaveServiceRequiredDocs(ServiceDocumentsRequirementsDTO service)
        {
            try
            {
                if (!ModelState.IsValid)
                    return RedirectToPage();

                int i = serviceDocuments.AddEditServiceRequiredDocuments(service).Result;
                return RedirectToPage("ServicesRequiredDocument", new { serviceRefId = service.ServiceId });
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
                int i = serviceDocuments.EnableDisableServiceRequiredDocuments(RefId).Result;
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