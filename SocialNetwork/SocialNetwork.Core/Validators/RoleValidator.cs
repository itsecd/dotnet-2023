using FluentValidation;
using SocialNetwork.Domain;

namespace SocialNetwork.Core.Validators;

/// <summary>
/// Проверка корректности роли.
/// </summary>
public class RoleValidator : AbstractValidator<Role>
{
	public RoleValidator()
	{
		RuleFor(role => role.Name).NotEmpty().WithMessage("Название роли не должно быть пустым.");
	}
}
