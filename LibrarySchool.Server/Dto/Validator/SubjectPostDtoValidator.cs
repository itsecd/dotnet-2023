using FluentValidation;
using LibrarySchoolServer.Dto;

namespace LibrarySchool.Server.Dto.Validator;

/// <summary>
/// ClassValidator for ClassType
/// </summary>
public class SubjectPostDtoValidator : AbstractValidator<SubjectPostDto>
{
    /// <summary>
    /// Constructor of class StudentPostDtoValidator
    /// </summary>
    public SubjectPostDtoValidator() 
    {
        RuleFor(subjectPostDto => subjectPostDto.SubjectName)
            .NotEmpty().WithMessage("'{PropertyName}' can not be null")
            .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters.");
        RuleFor(subjectPostDto => subjectPostDto.YearStudy)
            .NotEmpty().WithMessage("'{PropertyName}' can not be null")
            .GreaterThanOrEqualTo(1990).WithMessage("'{PropertyName}' more than 1990.");
    }
}
