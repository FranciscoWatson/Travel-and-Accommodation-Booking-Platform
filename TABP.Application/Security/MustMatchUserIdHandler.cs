using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace TABP.Application.Security;

public class MustMatchUserIdHandler : AuthorizationHandler<MustMatchUserIdRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MustMatchUserIdRequirement requirement)
    {
        var userIdFromClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var httpContext = context.Resource as HttpContext;
        var userIdFromRoute = httpContext?.Request.RouteValues["userId"] as string;

        if (userIdFromClaim == userIdFromRoute)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}