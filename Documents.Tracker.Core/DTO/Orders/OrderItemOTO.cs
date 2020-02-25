using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO.Orders
{
    public class OrderItemOTO
    {
        public int Id { get; set; }

        [Required]
        //public string OrderKey { get; set; }
        public int ProductId { get; set; }

        [Required]
        public string ProductKey { get; set; }
        public string ProductShortName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }
        public decimal ProductUnit { get; set; }
        public decimal Discount { get; set; }
        public string ImageUrl { get; set; }
        //[AutoMapper.IgnoreMap]
        public ProductOTO Product { get; set; }

    }
}