using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core
{
    internal class ProductsServices : MapperCore,
        IQueryProductDocuments,
        ICommandProductDocuments,
        IQueryProductServices

    {
        private readonly IServiceIssuedDocumentsCore serviceIssuedDocuments;
        private readonly IServiceRequiredDocumentsCore serviceRequiredDocuments;
        //private readonly IQueryGeneralService queryGeneralService;
        private readonly IProductsCore products;
        public ProductsServices(
            IProductsCore _products,
            //IQueryGeneralService _queryGeneralService,
            IServiceIssuedDocumentsCore _serviceIssuedDocuments
            , IServiceRequiredDocumentsCore _serviceRequiredDocuments)
        {
            //queryGeneralService = _queryGeneralService;
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

        public async Task<ICollection<ProductIssuedDocumentsOTO>> GetIssuedDocumentsByServiceId(int productUKey)
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






        public async Task<ICollection<ProductDocumentsRequirementsOTO>> GetRequiredDocumentsByServiceId(int productUKey)
        {
            try
            {
                return await serviceRequiredDocuments.GetRequiredDocumentsByServiceId(productUKey);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<ProductIssuedDocumentsOTO> GetServiceIssuedDocument(int IssuedDocId)
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

        public async Task<ProductDocumentsRequirementsOTO> GetServiceRequiredDocument(int requiredDocId)
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

        public async Task<ProductOTO> GetServiceDetailsByServiceId(int serviceid)
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
