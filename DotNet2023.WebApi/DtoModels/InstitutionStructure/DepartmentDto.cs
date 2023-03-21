using System.ComponentModel.DataAnnotations;

namespace DotNet2023.WebApi.DtoModels.InstitutionStructure;
public class DepartmentDto
{
    public string Id { get; set; } 
    public string? Name { get; set; }

    [RegularExpression(@"\\S+@\\S+\\.\\S+$")]
    public string? Email { get; set; }
    [RegularExpression(@"[0-9]{10}")]
    public string? Phone { get; set; }

    public string? IdHeadOfDepartment { get; set; }
    public string? IdFaculty { get; set; }
    public string? IdInstitute { get; set; }
}
