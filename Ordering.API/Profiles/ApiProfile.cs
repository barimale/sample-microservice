﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Ordering.API.API.Model;
using Ordering.Application.CQRS.Commands;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CreateOrderCommand, CreateOrderRequest>()
                .ForMember(p => p.CustomerId, pp => pp.MapFrom(src => src.CustomerId))
                .ReverseMap()
                .ForMember(p => p.CustomerId, pp => pp.MapFrom(src => src.CustomerId));
            CreateMap<CreateOrderCommand, Order>()
                .ReverseMap();
        }
    }
}
