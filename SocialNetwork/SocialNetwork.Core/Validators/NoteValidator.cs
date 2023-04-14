using FluentValidation;
using SocialNetwork.Domain;

namespace SocialNetwork.Core.Validators;

/// <summary>
/// Проверка корректности записи.
/// </summary>
public class NoteValidator : AbstractValidator<Note>
{
	public NoteValidator()
	{
		RuleFor(note => note.Name).NotEmpty().WithMessage("Название записи не должно быть пустым.");
		RuleFor(note => note.Description).NotEmpty().WithMessage("Описание записи не должно быть пустым.");
		RuleFor(note => note.CreationDate).NotEmpty().WithMessage("Некорректная дата.");
	}
}
