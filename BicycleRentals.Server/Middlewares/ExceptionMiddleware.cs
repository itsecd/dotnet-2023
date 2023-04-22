namespace BicycleRentals.Server.Middlewares;

/// <summary>
/// Обработчик запроса с исключением типа Exception.
/// </summary>
public class ExceptionMiddleware
{
	/// <summary>
	/// Следующий обработчик.
	/// </summary>
	public readonly RequestDelegate next;

	public ExceptionMiddleware(RequestDelegate next)
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
		catch (Exception) 
		{
			httpContext.Response.StatusCode = 500;
			await httpContext.Response.WriteAsJsonAsync(new { Message = "Internal Server Error!" });
		}
	}
}
