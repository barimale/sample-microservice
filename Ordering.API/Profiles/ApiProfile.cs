using AutoMapper;
using Ordering.API.API.Model;
using Ordering.Application.CQRS.Commands;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<CreateOrderCommand, CreateOrderRequest>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
        }
    }
}
