using Orders.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Documents.Tracker.Core.DTO.Orders
{
    public class OrderOTO
    {
        public OrderOTO()
        {
            OrderItems = new HashSet<OrderProductOTO>();
        }
        [MaxLength(200)]
        public string OrderKey { get; set; }

        [MaxLength(200)]
        public string ConsumerId { get; set; }
        public int ConsumerAddressId { get; set; }

        public int OrderStatusId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        public DateTime FinishedDate { get; set; }

        public OrderStatusDTO OrderStatus { get; set; }

        public bool IsDraft { get; set; }
        public ICollection<OrderProductOTO> OrderItems { get; set; }

        [AutoMapper.IgnoreMap]
        public ConsumersProfileOTO Consumer { get; set; }


    }
}
