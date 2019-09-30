﻿using AutoMapper;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class OrderIdentityProfile : Profile
    {
        public OrderIdentityProfile()
        {
            CreateMap<int, OrderIdentity>()
                .ConvertUsing(src => new OrderIdentity(src));

            CreateMap<OrderIdentity, int>()
                .ConvertUsing(src => src.Id);

            CreateMap<int, OrderDetailIdentity>()
                .ConvertUsing(src => new OrderDetailIdentity(src));

            CreateMap<OrderDetailIdentity, int>()
                .ConvertUsing(src => src.Id);
        }
    }
}
