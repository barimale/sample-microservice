using Ordering.Application.Exceptions;
using Ordering.Domain.AggregatesModel.BuyerAggregate;
using Ordering.Domain.AggregatesModel.OrderAggregate;

namespace Ordering.Application.Services.Sagas
{
    // compensation saga Use transaction classic here
    // saga for restapiclients
    public class AddOrderSagaService
    {
        //// services 
        /// buyer has to be extenral microservice
        //private readonly IBuyerService _buyerService; httpclient
        //private readonly IOrderService _orderService; httpclient
        //private readonly ILogger<AddOrderSagaService> _logger;

        //public AddOrderSagaService(
        //    IBuyerService buyerService,
        //    IOrderService orderService,
        //    ILogger<AddOrderSagaService> logger)
        //{
        //    _buyerService = buyerService;
        //    _orderService = orderService;
        //    _logger = logger;
        //}

        //public async Task<bool> Execute(Order order, Buyer buyer)
        //{
        //    try
        //    {
        //        await _buyerService.AddAsync(buyer);
        //        await _orderService.AddAsync(order);

        //        return true;
        //    }
        //    catch (AddBuyerException abe)
        //    {
        //        _logger.LogError(abe.Message);

        //        await _buyerService.RemoveAsync(buyer);
        //    }
        //    catch (AddOrderException aoe)
        //    {
        //        _logger.LogError(aoe.Message);

        //        await _orderService.RemoveAsync(order);
        //        await _buyerService.RemoveAsync(buyer);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.Message);
        //        throw;
        //    }

        //    return false;
        //}
    }
}
