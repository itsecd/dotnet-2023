using SocialNetwork.Core;

namespace SocialNetwork.Web.Middlewares;

/// <summary>
/// Обработчик запроса с исключением типа Exception.
/// </summary>
public class ValidationExceptionMiddleware
{
	/// <summary>
	/// Следующий обработчик.
	/// </summary>
	public readonly RequestDelegate next;

	/// <summary>
	/// Создает обработчик запроса с помощью указанных данных.
	/// </summary>
	/// <param name="next">Следующий обработчик</param>
	public ValidationExceptionMiddleware(RequestDelegate next) 
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
		catch (ValidationException ex)
		{
			httpContext.Response.StatusCode = 400;
			await httpContext.Response.WriteAsJsonAsync(ex.Message);
		}
		catch (FluentValidation.ValidationException ex) 
		{
			httpContext.Response.StatusCode = 400;
			await httpContext.Response.WriteAsJsonAsync(ex.Message);
		}
	}
}
