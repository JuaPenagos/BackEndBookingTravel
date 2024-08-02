using BackEndBookingTravel.Utility.Helpers;

namespace BackEndBookingTravel.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (UnauthorizedAccessException)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new ApiResponse<object> { Success = false, Message = "Unauthorized access." });
            }
            catch (GenericException ex)
            {
                context.Response.StatusCode = StatusCodes.Status204NoContent;
                await context.Response.WriteAsJsonAsync(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            { 
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new ApiResponse<object> { Success = false, Message = "An error occurred while processing your request." });
            }
        }
    }
}