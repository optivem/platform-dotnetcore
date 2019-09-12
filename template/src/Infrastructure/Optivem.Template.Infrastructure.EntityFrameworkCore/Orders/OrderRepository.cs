﻿using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderRepository : Repository<DatabaseContext, Order, OrderIdentity, OrderRecord, int>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        public IEnumerable<Order> Get(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        protected override Order GetAggregateRoot(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerId);
            OrderStatus status = (OrderStatus)record.StatusId; // TODO: VC
            var orderDetails = record.OrderDetails.Select(GetOrderDetail).ToList().AsReadOnly();

            return new Order(id, customerId, status, orderDetails);
        }

        private OrderDetail GetOrderDetail(OrderDetailRecord record)
        {
            var id = new OrderDetailIdentity(record.Id);
            var productId = new ProductIdentity(record.ProductId);
            var quantity = record.Quantity;
            var unitPrice = record.UnitPrice;
            var status = (OrderDetailStatus)record.StatusId; // TODO: VC

            return new OrderDetail(id, productId, quantity, unitPrice, status);
        }

        protected override OrderIdentity GetIdentity(OrderRecord record)
        {
            throw new NotImplementedException();
        }

        protected override OrderRecord GetRecord(OrderIdentity identity)
        {
            throw new NotImplementedException();
        }

        protected override OrderRecord GetRecord(Order aggregateRoot)
        {
            throw new NotImplementedException();
        }
    }
}
