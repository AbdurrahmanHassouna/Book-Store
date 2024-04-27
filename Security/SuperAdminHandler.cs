using AprilBookStore.Security;
using Microsoft.AspNetCore.Authorization;

namespace AprilBookStore.Security
{
    public class SuperAdminHandler : AuthorizationHandler<RoleEditingRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleEditingRequirement requirement)
        {
            if (context.User.IsInRole("SuperAdmin"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
