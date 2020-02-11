using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO.Orders;
using Orders.Core.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documents.Tracker.Core.CompositeServices.Services.Orders
{
    internal class OrdersServices : MapperCore, IQueryOrderService, ICommandOrderService
    {
        private readonly IOrderServices _orderServices;
        private readonly IQueryConsumersServices _queryConsumers;
        private readonly IQueryProductServices _productServices;
        public OrdersServices(IOrderServices orderServices
            , IQueryConsumersServices queryConsumers
            , IQueryProductServices productServices
            )
        {
            _orderServices = orderServices;
            _queryConsumers = queryConsumers;
            _productServices = productServices;
        }
        public async Task<ICollection<OrderOTO>> GetAllOrders()
        {
            try
            {
                var x = await _orderServices.GetAllOrders();
                return Mapper.Map<ICollection<OrderOTO>>(x);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<OrderOTO> GetOrderDetailsByOrderId(string id)
        {
            try
            {
                var x = await _orderServices.GetOrderDetailsWithProductByOrderKey(id);
                var orderDetails = Mapper.Map<OrderOTO>(x);
                if (orderDetails != null)
                {
                    foreach (var item in orderDetails.OrderItems)
                    {
                        var product = await _productServices.GetServiceDetailsByServiceId(item.ProductId);
                        item.Product = product;
                    }

                    var cosnumer = await _queryConsumers.GetSingleConsumerWithAddressByConsumerId(orderDetails.ConsumerId);
                    if (cosnumer != null)
                    {
                        orderDetails.Consumer = cosnumer;
                    }
                }

                return Mapper.Map<OrderOTO>(orderDetails);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderOTO> SetOrderStatus(string orderkey, int StatusEnumId)
        {
            try
            {
                var order = await _orderServices.ChangeOrderStatus(StatusEnumId, orderkey);
                return Mapper.Map<OrderOTO>(order);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
