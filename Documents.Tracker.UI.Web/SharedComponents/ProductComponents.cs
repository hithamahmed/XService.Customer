using Documents.Tracker.Core;
using Documents.Tracker.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Documents.Tracker.UI.Web.SharedComponents
{
    [ViewComponent(Name = "ProductRequiredDocuments")]
    public class ProductRequiredDocumentsComponents : ViewComponent
    {
        private readonly IQueryProductDocumentServices _queryProductDocuments;
        public ICollection<ProductDocumentsRequirementsOTO> ProductDocumentsRequirements { get; set; }
        public ProductRequiredDocumentsComponents(IQueryProductDocumentServices queryProductDocuments)
        {
            _queryProductDocuments = queryProductDocuments;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            ProductDocumentsRequirements = await _queryProductDocuments.GetRequiredDocuments(productId);
            return View(ProductDocumentsRequirements);
        }
    }
}
