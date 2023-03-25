using FluentValidation;
using SocialNetwork.Domain;

namespace SocialNetwork.Core.Validators;

/// <summary>
/// Проверка корректности пользователя.
/// </summary>
public class UserValidator : AbstractValidator<User>
{
	/// <summary>
	/// Валидация объекта пользователя.
	/// </summary>
	public UserValidator()
	{
		RuleFor(user => user.FirstName).NotEmpty().WithMessage("Название группы не должно быть пустым.");
		RuleFor(user => user.LastName).NotEmpty().WithMessage("Название группы не должно быть пустым.");
		RuleFor(user => user.Patronymic).NotEmpty().WithMessage("Название группы не должно быть пустым.");
		RuleFor(user => user.Gender).NotEmpty().WithMessage("Название группы не должно быть пустым.");
		RuleFor(user => user.BirthDate).NotEmpty().WithMessage("Некорректная дата.");
		RuleFor(user => user.RegistrationDate).NotEmpty().WithMessage("Некорректная дата.");
	}
}
