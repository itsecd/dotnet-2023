using SocialNetwork.Core;

namespace SocialNetwork.Web.Middlewares;

/// <summary>
/// Обработчик запроса с исключением типа NotFoundException.
/// </summary>
public class NotFoundExceptionMiddleware
{
	/// <summary>
	/// Следующий обработчик.
	/// </summary>
	public readonly RequestDelegate next;

	public NotFoundExceptionMiddleware(RequestDelegate next) 
	{
		this.next = next;
	}

	/// <summary>
	/// Обработка запроса.
	/// </summary>
	/// <param name="httpContext">Запрос.</param>
	public async Task Invoke(HttpContext httpContext)
	{
		try
		{
			await next(httpContext);
		}
		catch (NotFoundException ex)
		{
			httpContext.Response.StatusCode = 404;
			await httpContext.Response.WriteAsJsonAsync(ex.Message);
		}
	}
}
