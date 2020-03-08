using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using General.Services.Core.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.Repositories
{
    internal class ProductsCore : MapperCore, IProductsCore
    {
        private readonly IServiceRequiredDocumentsCore _requiredDocumentsCore;
        private readonly IServiceIssuedDocumentsCore _issuedDocumentsCore;
        private readonly IProducts _products;
        public ProductsCore(
            IServiceRequiredDocumentsCore requiredDocumentsCore,
            IServiceIssuedDocumentsCore issuedDocumentsCore,
            IProducts products)
        {

            _products = products;
            _issuedDocumentsCore = issuedDocumentsCore;
            _requiredDocumentsCore = requiredDocumentsCore;
        }

        public async Task<ProductOTO> GetProductDetailsByProductId(int id)
        {
            try
            {
                var singleproductDTO = await _products.GetProductById(id);
                var product = Mapper.Map<ProductOTO>(singleproductDTO);

                if (product != null)
                {
                    var issuedDocs = await _issuedDocumentsCore.GetIssuedDocumentsByServiceId(id);
                    var requiredDocs = await _requiredDocumentsCore.GetRequiredDocuments(id);
                    product.ProductDocumentsRequirements = requiredDocs;
                    product.ProductIssuedDocuments = issuedDocs;
                }

                return product;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<ProductOTO>> GetProductsWithCategories()
        {
            try
            {
                var _List = await _products.GetAllProductsWithCategory();
                return Mapper.Map<ICollection<ProductOTO>>(_List);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
