using API.extensions;
using API.interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next(); //API action has complemted execution

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return; //if user is not authenticated, exit

            var userId = resultContext.HttpContext.User.GetUserId();
            var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
            var user = await repo.GetUserByIdAsync(userId);
            user.LastActive = DateTime.UtcNow; //update last active time
            await repo.SaveAllAsync(); //save changes to the database
        }
    }
}