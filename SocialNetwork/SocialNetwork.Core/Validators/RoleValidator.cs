using FluentValidation;
using SocialNetwork.Domain;

namespace SocialNetwork.Core.Validators;

/// <summary>
/// Проверка корректности роли.
/// </summary>
public class RoleValidator : AbstractValidator<Role>
{
	/// <summary>
	/// Валидация объекта роли.
	/// </summary>
	public RoleValidator()
	{
		RuleFor(role => role.Name).NotEmpty().WithMessage("Название роли не должно быть пустым.");
	}
}
