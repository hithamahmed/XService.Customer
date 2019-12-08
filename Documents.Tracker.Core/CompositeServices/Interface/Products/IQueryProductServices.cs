using Documents.Tracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Interface.Products
{
    public interface IQueryProductServices
    {
        Task<ProductOTO> GetProductServiceWithRequiredDocuments(int productUKey);
    }
}
