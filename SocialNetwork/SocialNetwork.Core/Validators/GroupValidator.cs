using FluentValidation;
using SocialNetwork.Domain;

namespace SocialNetwork.Core.Validators;

/// <summary>
/// Проверка корректности группы.
/// </summary>
public class GroupValidator : AbstractValidator<Group>
{
	/// <summary>
	/// Валидация объекта группы.
	/// </summary>
	public GroupValidator()
	{
		RuleFor(group => group.Name).NotEmpty().WithMessage("Название группы не должно быть пустым.");
		RuleFor(group => group.Description).NotEmpty().WithMessage("Описание группы не должно быть пустым.");
		RuleFor(group => group.CreationDate).NotEmpty().WithMessage("Некорректная дата.");
	}
}
