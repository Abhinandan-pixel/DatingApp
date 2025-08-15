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
            var uow = resultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            var user = await uow.UserRepository.GetUserByIdAsync(userId);
            user.LastActive = DateTime.UtcNow; //update last active time
            await uow.Completed(); //save changes to the database
        }
    }
}