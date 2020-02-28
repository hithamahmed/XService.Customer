using System.ComponentModel.DataAnnotations;
using TodoTasks.Commons.DTO;

namespace Documents.Tracker.Core.DTO.Orders
{
    public class OrderProductOTO
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductKey { get; set; }
        public string ProductShortName { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }
        public decimal ProductUnit { get; set; }
        public decimal Discount { get; set; }
        public string ImageUrl { get; set; }
        public ProductOTO Product { get; set; }
        //public TaskStatusDTO TaskStatus { get; set; } 
    }
}