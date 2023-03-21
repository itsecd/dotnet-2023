using DotNet2023.Domain.InstituteDocumentation;

namespace DotNet2023.WebApi.DtoModels.InstituteDocumentation;
public class SpecialityDto
{
    public string Code { get; set; } 
    public string? Title { get; set; }
    public StudyFormat? StudyFormat { get; set; }
}
