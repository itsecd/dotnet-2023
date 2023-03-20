using FluentValidation;

namespace DotNet2023.Application.Institutions.Commands.CreateInstitutions;
public class CreateInstitutionsCommandValidator : AbstractValidator<CreateInstitutionsCommand>
{
    public CreateInstitutionsCommandValidator()
    {
        // TODO complete the validation
        RuleFor(createCommand =>
        createCommand.FullName).NotEmpty().MaximumLength(250);
    }
}
