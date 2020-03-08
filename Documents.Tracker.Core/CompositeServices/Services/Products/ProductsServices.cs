using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    internal class ProductsServices : MapperCore,
        IQueryProductDocumentServices,
        ICommandProductDocuments,
        IQueryProductServices

    {
        private readonly IServiceIssuedDocumentsCore serviceIssuedDocuments;
        private readonly IServiceRequiredDocumentsCore serviceRequiredDocuments;
        private readonly IProductsCore products;
        public ProductsServices(
            IProductsCore _products
            ,IServiceIssuedDocumentsCore _serviceIssuedDocuments
            , IServiceRequiredDocumentsCore _serviceRequiredDocuments)
        {
            serviceIssuedDocuments = _serviceIssuedDocuments;
            serviceRequiredDocuments = _serviceRequiredDocuments;
            products = _products;
        }

        public async Task<int> AddEditServiceIssuedDocuments(ProductIssuedDocumentsOTO serviceDocumentsIssued)
        {
            try
            {
                return await serviceIssuedDocuments.AddEditServiceIssuedDocuments(serviceDocumentsIssued);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddEditServiceRequiredDocuments(ProductDocumentsRequirementsOTO serviceDocumentsRequirements)
        {
            try
            {
                return await serviceRequiredDocuments.AddEditServiceRequiredDocuments(serviceDocumentsRequirements);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> EnableDisableServiceIssuedDocuments(int IssuedDocId)
        {
            try
            {
                return await serviceIssuedDocuments.EnableDisableServiceIssuedDocuments(IssuedDocId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> EnableDisableServiceRequiredDocuments(int requiredDocId)
        {
            try
            {
                return await serviceRequiredDocuments.EnableDisableServiceRequiredDocuments(requiredDocId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<ProductIssuedDocumentsOTO>> GetIssuedDocuments(int productUKey)
        {
            try
            {
                return await serviceIssuedDocuments.GetIssuedDocumentsByServiceId(productUKey);
            }
            catch (Exception)
            {

                throw;
            }
        }






        public async Task<ICollection<ProductDocumentsRequirementsOTO>> GetRequiredDocuments(int productId)
        {
            try
            {
                return await serviceRequiredDocuments.GetRequiredDocuments(productId);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<ProductIssuedDocumentsOTO> GetSingleProductIssuedDocument(int IssuedDocId)
        {
            try
            {
                return await serviceIssuedDocuments.GetServiceIssuedDocument(IssuedDocId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDocumentsRequirementsOTO> GetSingleProductRequiredDocument(int requiredDocId)
        {
            try
            {
                return await serviceRequiredDocuments.GetServiceRequiredDocument(requiredDocId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductOTO> GetProduct(int serviceid)
        {
            try
            {
                return await products.GetProductDetailsByProductId(serviceid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<ProductOTO>> GetListOfProductsWithCategory()
        {
            try
            {
                return await products.GetProductsWithCategories();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
