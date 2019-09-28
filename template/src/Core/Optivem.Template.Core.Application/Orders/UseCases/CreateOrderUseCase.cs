﻿using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class CreateOrderUseCase : CreateAggregateUseCase<IOrderRepository, CreateOrderRequest, CreateOrderResponse, Order, OrderIdentity, int>
    {
        public CreateOrderUseCase(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}