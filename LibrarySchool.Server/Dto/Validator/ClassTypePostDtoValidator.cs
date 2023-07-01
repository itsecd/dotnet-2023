using FluentValidation;
using LibrarySchoolServer.Dto;

namespace LibrarySchool.Server.Dto.Validator;

/// <summary>
/// ClassValidator for ClassType
/// </summary>
public class ClassTypePostDtoValidator : AbstractValidator<ClassTypePostDto>
{
    /// <summary>
    /// Constructor of class StudentPostDtoValidator
    /// </summary>
    public ClassTypePostDtoValidator() 
    {
        RuleFor(classTypePostDto => classTypePostDto.Number)
            .NotEmpty().WithMessage("'{PropertyName}' can not be null")
            .GreaterThanOrEqualTo(1000).WithMessage("'{PropertyName}' can not less than 1000")
            .LessThanOrEqualTo(9999).WithMessage("'{PropertyName}' can not more than 9999'");
        RuleFor(classTypePostDto => classTypePostDto.Letter)
            .NotEmpty().WithMessage("'{PropertyName}' can not be null");
    }
}
