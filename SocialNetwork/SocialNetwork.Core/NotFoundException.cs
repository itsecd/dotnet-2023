namespace SocialNetwork.Core;

/// <summary>
/// Исключение для случая, когда объект, который необходимо получить, не найден.
/// </summary>
public class NotFoundException : Exception
{
	public NotFoundException(string message) : base(message) { }
}
