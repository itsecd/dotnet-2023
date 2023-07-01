using FluentValidation;
using LibrarySchoolServer.Dto;

namespace LibrarySchool.Server.Dto.Validator;

/// <summary>
/// ClassValidator for student
/// </summary>
public class StudentPostDtoValidator : AbstractValidator<StudentPostDto>
{
    /// <summary>
    /// Constructor of class StudentPostDtoValidator
    /// </summary>
    public StudentPostDtoValidator()
    {
        RuleFor(studentPostDto => studentPostDto.StudentName)
            .NotEmpty()
            .Matches(@"^[A-Za-z\s]*$")
            .WithMessage("'{PropertyName}' should only contain letters.");
        RuleFor(studentPostDto => studentPostDto.ClassId)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("'{PropertyName}' more than 0.");
        RuleFor(studentPostDto => studentPostDto.DateOfBirth)
            .GreaterThanOrEqualTo(new DateTime(1990, 1, 1))
            .WithMessage("'{PropertyName}' more than 01-01-1990.");
    }
}

