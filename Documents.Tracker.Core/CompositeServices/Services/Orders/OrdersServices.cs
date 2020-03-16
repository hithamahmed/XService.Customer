using Documents.Tracker.Core.Config.Mapper;
using Documents.Tracker.Core.DTO.Orders;
using Orders.Core;
using Orders.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                var ordersList = await _orderServices.GetAllOrders();
                var orders = Mapper.Map<ICollection<OrderOTO>>(ordersList);
                foreach (var item in orders)
                {
                    var consumerPofile = await _queryConsumers.GetSingleConsumerWithAddressByConsumerId(item.ConsumerId);
                    item.Consumer = consumerPofile;
                }
                return orders;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<OrderOTO> GetSingleOrder(string OrderKey)
        {
            try
            {
                var x = await _orderServices.GetOrderDetailsWithProduct(OrderKey);
                var order = Mapper.Map<OrderOTO>(x);
                if (order != null)
                {
                    var cosnumer = await _queryConsumers.GetSingleConsumerWithAddressByConsumerId(order.ConsumerId);
                    if (cosnumer != null)
                    {
                        order.Consumer = cosnumer;
                    }
                }

                return Mapper.Map<OrderOTO>(order);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<OrderOTO> GetSingleOrder(int OrderId)
        {
            try
            {
                var x = await _orderServices.GetOrderDetailsWithProduct(OrderId);
                var order = Mapper.Map<OrderOTO>(x);
                if (order != null)
                {
                    var cosnumer = await _queryConsumers.GetSingleConsumerWithAddressByConsumerId(order.ConsumerId);
                    if (cosnumer != null)
                    {
                        order.Consumer = cosnumer;
                    }
                }

                return Mapper.Map<OrderOTO>(order);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<OrderOTO> GetOrderbyOrderDetailId(int OrderDetailId)
        {
            try
            {
                var orderDetails = await _orderServices.GetSingleOrderDetailsWithProductById(OrderDetailId);
                var singleOrder = await _orderServices.GetSingleOrderHeader(orderDetails.OrderKey);

                var order = Mapper.Map<OrderOTO>(singleOrder);
                if (order != null)
                {
                    var cosnumer = await _queryConsumers.GetSingleConsumerWithAddressByConsumerId(order.ConsumerId);
                    if (cosnumer != null)
                    {
                        order.Consumer = cosnumer;
                    }
                }
                order.OrderItems.Add(Mapper.Map<OrderProductOTO>(orderDetails));

                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public async Task<ICollection<OrderProductOTO>> GetOrdersByStatus(int orderstausId)
        //{
        //    try
        //    {
        //        Expression<Func<OrderProductOTO, bool>> predicate = x => x.ProductId == orderstausId;

        //        var orders = await _orderServices.GetOrders(x => x.OrderStatusId == orderstausId);
        //        List<string> Orderskeys = (from i in orders select i.OrderKey).ToList();

        //        var orderItems = await _orderServices.GetOrderProducts(x => Orderskeys.Contains(x.OrderKey));

        //        var orderList = Mapper.Map<ICollection<OrderProductOTO>>(orderItems);

        //        foreach (var item in orderList.ToList())
        //        {
        //            var product = await _productServices.GetProduct(item.ProductId);
        //            item.Product = product;
        //        }
        //        return orderList;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
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
        public async Task<ICollection<OrderProductOTO>> GetOrderProducts(int OrderId)
        {
            try
            {
                var orderKey = await _orderServices.GetOrderKeyById(OrderId);
                var orderlist = await _orderServices.GetOrderProducts(x => x.OrderKey.Equals(orderKey));
                return Mapper.Map<ICollection<OrderProductOTO>>(orderlist);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<OrderProductOTO>> GetOrderProducts(string OrderKey)
        {
            try
            {
                var orderlist = await _orderServices.GetOrderProducts(x => x.OrderKey.Equals(OrderKey));
                return Mapper.Map<ICollection<OrderProductOTO>>(orderlist);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderPaymentOTO> GetSingleOrderPayment(string OrderKey)
        {
            try
            {
                var orderPayment = await _orderServices.GetSingleOrderPayment(OrderKey);
                return Mapper.Map<OrderPaymentOTO>(orderPayment);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<OrderOTO>> GetOrders(string Consumerid)
        {
            try
            {
                var x = await _orderServices.GetOrders(x => x.ConsumerId.Equals(Consumerid));
                return Mapper.Map<ICollection<OrderOTO>>(x);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<OrderProductOTO>> GetPendingOrder(string OrderKey)
        {
            try
            {
                Expression<Func<OrderProductDTO, bool>> expr = x =>
                x.OrderKey.Equals(OrderKey)
                && x.OrderStatusId < Convert.ToInt32(OrderExt.OrderStatusEnums.Shipped);

                var orderproduct = await _orderServices.GetOrderProducts(expr);
                return Mapper.Map<ICollection<OrderProductOTO>>(orderproduct);
                //Expression<Func<OrderOTO, bool>> expr = x =>
                //x.OrderKey.Equals(OrderKey) 
                //&& x.OrderStatusId < (int)OrderExt.OrderStatusEnums.Shipped;
                //var predicate = Mapper.Map<Expression<Func<OrderDTO, bool>>>(expr);
                //var _orders = await _orderServices.GetFullOrders(predicate);
                //var orderList = Mapper.Map<ICollection<OrderOTO>>(_orders);
                //return orderList;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
