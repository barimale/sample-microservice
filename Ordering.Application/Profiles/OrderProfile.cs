﻿using AutoMapper;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.BuyerAggregate;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //CreateMap<List<Order>, List<OrderDto>>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<PaymentMethod, PaymentDto>().ReverseMap();
        }
    }
}
