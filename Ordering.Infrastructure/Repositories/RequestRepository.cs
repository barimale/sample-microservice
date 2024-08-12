using BuildingBlocks.Domain.Request;
using BuildingBlocks.Domain.Response;
using BuildingBlocks.Domain.SeedWork;
using Ordering.Domain.AggregatesModel.BuyerAggregate;
using System;

namespace Ordering.Infrastructure.Repositories;

public class RequestRepository
    : IRequestRepository
{
    private readonly OrderingContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public RequestRepository(OrderingContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Request Add(Request request)
    {
        if (request.IsTransient())
        {
            return _context.Requests
                .Add(request)
                .Entity;
        }

        return request;
    }
}
