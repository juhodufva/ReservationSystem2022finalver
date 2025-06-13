using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ReservationSystem2022.Filters
{
    public class ApiKeyHeaderOperationFilter : IOperationFilter
    {
        private readonly string _apiKey;

        public ApiKeyHeaderOperationFilter(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ApiKey",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString(_apiKey)
                }
            });
        }
    }
}
