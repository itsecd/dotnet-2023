using LibrarySchool.Server.Exceptions;

namespace LibrarySchool.Server.Middlewares;

/// <summary>
/// class handle middleware on request
/// </summary>
public class GlobalExeptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExeptionHandlingMiddleware> _logger;

    /// <summary>
    /// Constructor of class
    /// </summary>
    /// <param name="logger">log information</param>
    public GlobalExeptionHandlingMiddleware(ILogger<GlobalExeptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Constructor of class
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = ex.ErrorCode;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (BadRequestException ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = ex.ErrorCode;
            await context.Response.WriteAsync(ex.Message);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Some thing went wrong");
        }
    }
}
