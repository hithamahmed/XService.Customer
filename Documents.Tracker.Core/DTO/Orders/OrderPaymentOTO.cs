using System;
using System.Collections.Generic;
using System.Text;

namespace Documents.Tracker.Core.DTO.Orders
{
    public class OrderPaymentOTO
    {
        public int Id { get; set; }
        public DateTime PaidDate { get; set; }
        public decimal AmountPaid { get; set; }
        //public int MethodName { get; set; }
        
    }
}
