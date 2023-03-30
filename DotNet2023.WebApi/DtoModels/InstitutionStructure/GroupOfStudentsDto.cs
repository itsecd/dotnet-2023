using System.ComponentModel.DataAnnotations;

namespace DotNet2023.WebApi.DtoModels.InstitutionStructure;
public class GroupOfStudentsDto
{
    public string Id { get; set; }
    public string? Name { get; set; }

    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public string? Email { get; set; }
    [RegularExpression(@"[0-9]{10}")]
    public string? Phone { get; set; }

    public string? IdSpeciality { get; set; }
    public string? IdDepartment { get; set; }
}
