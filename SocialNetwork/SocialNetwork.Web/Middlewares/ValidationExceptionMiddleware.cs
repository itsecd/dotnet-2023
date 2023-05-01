using SocialNetwork.Core;
using System.Text.RegularExpressions;

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
			await httpContext.Response
				.WriteAsJsonAsync(ex.Errors.Select(x => x.ErrorMessage).ToList());
		}
	}
}
