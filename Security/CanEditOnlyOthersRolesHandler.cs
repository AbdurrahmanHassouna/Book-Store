﻿using AprilBookStore.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace AprilBookStore.Security
{
    public class CanEditOnlyOthersRolesHandler : AuthorizationHandler<RoleEditingRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleEditingRequirement requirement)
        {
            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if (authFilterContext == null)
            {
                return Task.CompletedTask;
            }
            string loggedInAdminId = context.User.Claims.FirstOrDefault(c => c.Type==ClaimTypes.NameIdentifier).Value;
            string EditedUserId = authFilterContext.HttpContext.Request.Query["id"];
            if (context.User.IsInRole("Admin") &&
                context.User.HasClaim(claim => claim.Type == "Edit Role" && claim.Value == "true") &&
                EditedUserId.ToLower() != loggedInAdminId.ToLower())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;


        }
    }
}
