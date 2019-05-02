using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace StsServerIdentity
{
    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (requirement == null)
                throw new ArgumentNullException(nameof(requirement));

            if (context.User.Identity.Name != null && context.User.Identity.Name.ToLower() == "damien_bod@hotmail.com")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}