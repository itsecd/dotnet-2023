using System.ComponentModel.DataAnnotations;

namespace DotNet2023.WebApi.DtoModels.InstitutionStructure;
public class FacultyDto
{
    public string Id { get; set; }
    public string? Name { get; set; }

    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public string? Email { get; set; }
    [RegularExpression(@"[0-9]{10}")]
    public string? Phone { get; set; }

    public string? IdDean { get; set; }
    public string? IdInstitute { get; set; }
}
