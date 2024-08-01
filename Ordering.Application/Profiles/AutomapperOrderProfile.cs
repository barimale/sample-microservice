using AutoMapper;
using Ordering.Application.Dtos;
using Ordering.Domain.AggregatesModel.BuyerAggregate;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Profiles
{
    public class AutomapperOrderProfile : Profile
    {
        public AutomapperOrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<PaymentMethod, PaymentDto>().ReverseMap();
        }
    }
}
