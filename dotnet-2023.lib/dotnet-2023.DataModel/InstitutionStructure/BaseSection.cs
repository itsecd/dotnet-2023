using System.ComponentModel.DataAnnotations;

namespace dotnet_2023.DataModel.InstitutionStructure;
public class BaseSection
{
    [Required]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }

    [RegularExpression(@"\\S+@\\S+\\.\\S+$")]
    public string? Email { get; set; }
    [RegularExpression(@"[0-9]{11}")]
    public string? Phone { get; set; }
}
