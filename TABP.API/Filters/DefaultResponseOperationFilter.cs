using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Travel_and_Accommodation_Booking_Platform.Filters;

public class DefaultResponseOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var excludeWithAttribute = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .Any(attr => attr is NoDefaultResponsesAttribute);

        if (excludeWithAttribute)
            return;
        
        operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized - The user is not authenticated" });
        operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden - The user does not have permission" });
    }
}