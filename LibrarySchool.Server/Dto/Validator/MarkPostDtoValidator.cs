using FluentValidation;
using LibrarySchoolServer.Dto;

namespace LibrarySchool.Server.Dto.Validator;

/// <summary>
/// ClassValidator for ClassType
/// </summary>
public class MarkPostDtoValidator : AbstractValidator<MarkPostDto>
{
    /// <summary>
    /// Constructor of class StudentPostDtoValidator
    /// </summary>
    public MarkPostDtoValidator() 
    {
        RuleFor(markPostDto => markPostDto.MarkValue)
            .NotEmpty().WithMessage("'{PropertyName}' can not be null")
            .GreaterThanOrEqualTo(2).WithMessage("'{PropertyName}' can not less than 2")
            .LessThanOrEqualTo(5).WithMessage("'{PropertyName}' can not more than 5'");      
        RuleFor(classTypePostDto => classTypePostDto.StudentId)
            .NotEmpty().WithMessage("'{PropertyName}' can not be null");
        RuleFor(classTypePostDto => classTypePostDto.SubjectId)
            .NotEmpty().WithMessage("'{PropertyName}' can not be null");
    }
}
