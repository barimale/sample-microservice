using AutoMapper;
using BuildingBlocks.API.Pagination;
using Ordering.API.Model.order;
using Ordering.Application.CQRS.Commands;
using Ordering.Application.CQRS.Queries;
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

            CreateMap<PaginationRequest, GetOrdersQuery>()
                .ForPath(p => p.PaginationRequest.PageIndex, pp => pp.MapFrom(src => src.PageIndex))
                .ForPath(p => p.PaginationRequest.PageSize, pp => pp.MapFrom(src => src.PageSize))
                .ReverseMap();

            CreateMap<CreateOrderCommand, Order>()
                .ReverseMap();

            CreateMap<CreateOrderResult, CreateOrderResponse>();
        }
    }
}
