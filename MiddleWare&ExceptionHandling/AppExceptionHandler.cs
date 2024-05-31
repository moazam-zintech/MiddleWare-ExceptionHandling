using Microsoft.AspNetCore.Diagnostics;

namespace MiddleWare_ExceptionHandling
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var responce = new ErrorResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                ExceptionMessage = exception.Message,
                Title = "Something went wrong"
            };
            await httpContext.Response.WriteAsJsonAsync(responce,cancellationToken);
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return true;
        }
    }
}
