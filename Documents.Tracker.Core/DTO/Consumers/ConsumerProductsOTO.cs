using Documents.Tracking.Data.Entities;
using General.Services.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO
{
    public class ConsumerProductsOTO : CoreBaseOTO
    {

        //public ServiceCategoryDTO ServiceCategory { get; set; }

        public virtual Product Product { get; set; }
        public int ConsumerId { get; set; }
        public int ProductId { get; set; }
        public string ProductUKey { get; set; }
        [DataType(DataType.Date)] public DateTime StartDate { get; set; }

        [DataType(DataType.Date)] public DateTime? FinishedDate { get; set; }

        public int CurrentServiceStatusId { get; set; }

        public DocStatus DocStatus { get; set; }
    }
}
