namespace SocialNetwork.Web.Middlewares;

/// <summary>
/// Обработчик запроса с исключением типа Exception.
/// </summary>
public class ExceptionMiddleware
{
	/// <summary>
	/// Следующий обработчик.
	/// </summary>
	public readonly RequestDelegate next;

	/// <summary>
	/// Создает обработчик запроса с помощью указанных данных.
	/// </summary>
	/// <param name="next">Следующий обработчик</param>
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
			await httpContext.Response.WriteAsJsonAsync(new { Message = "Внутренняя ошибка сервера!" });
		}
	}
}
