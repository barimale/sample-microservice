﻿using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Ordering.API.API.Model;
using Ordering.API.API.v1._0.order_endpoint.post_orders.Validators;
using Ordering.Application.CQRS.Commands;

namespace Ordering.API.API.v1._0.order_endpoint.delete_orders.Filter
{
    public class CreateOrderRequestIsValidFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        private readonly CreateOrderRequestValidator _createOrderRequestValidator;

        public CreateOrderRequestIsValidFilter(
            ILoggerFactory loggerFactory,
            CreateOrderRequestValidator createOrderRequestValidator)
        {
            _logger = loggerFactory.CreateLogger<CreateOrderRequestIsValidFilter>();
            _createOrderRequestValidator = createOrderRequestValidator;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext efiContext,
            EndpointFilterDelegate next)
        {
            var command = efiContext.GetArgument<CreateOrderRequest>(0);
            var validationResult = await _createOrderRequestValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning(validationResult.ToString());
                //return Results.Problem(validationResult.Errors.Select(p => p.ErrorMessage.ToString()));
                return Results.Problem(
                    validationResult
                    .Errors
                    .Select(p => p.ErrorMessage.ToString())
                    .First());

            }

            return await next(efiContext);
        }
    }
}