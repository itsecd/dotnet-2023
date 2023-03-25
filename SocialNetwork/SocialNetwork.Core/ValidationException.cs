namespace SocialNetwork.Core;

/// <summary>
/// Пользовательское исключение.
/// </summary>
public class ValidationException : Exception
{
	/// <summary>
	/// Создание пользовательского исключения с помощью указанных параметров.
	/// </summary>
	/// <param name="message">Текст сообщения.</param>
	public ValidationException(string message) : base(message) { }
}
