using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyProject.API.Filters
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var accessToken = context.HttpContext.Request.Cookies["access_token"];
            if (accessToken != "1234")
                context.Result = new UnauthorizedObjectResult(context.ModelState);
        }
    }
}
