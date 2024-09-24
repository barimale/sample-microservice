using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ordering.API.SwaggerFilters
{
    public class AddCustomHeaderParameter
        : IOperationFilter
    {
        public void Apply(
            OpenApiOperation operation,
            OperationFilterContext context)
        {
            if (operation.Parameters is null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Identity",
                In = ParameterLocation.Header,
                Description = "X-Identity here",
                Required = true,
            });
        }
    }
}
