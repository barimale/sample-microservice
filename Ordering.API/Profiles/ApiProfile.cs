using AutoMapper;
using Ordering.API.API.Model;
using Ordering.Application.CQRS.Commands;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.API.Profiles
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

            CreateMap<CreateOrderResult, CreateOrderResponse>();
        }
    }
}
