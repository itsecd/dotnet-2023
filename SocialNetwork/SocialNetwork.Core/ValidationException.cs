namespace SocialNetwork.Core;

/// <summary>
/// Пользовательское исключение.
/// </summary>
public class ValidationException : Exception
{
	public ValidationException(string message) : base(message) { }
}
