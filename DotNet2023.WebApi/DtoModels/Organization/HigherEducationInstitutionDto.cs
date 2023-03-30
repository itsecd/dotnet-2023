using DotNet2023.Domain.Organization;
using System.ComponentModel.DataAnnotations;

namespace DotNet2023.WebApi.DtoModels.Organization;
public class HigherEducationInstitutionDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? FullName { get; set; }
    public string? Initials { get; set; }

    public string? LegalAddress { get; set; }


    [RegularExpression(@"[0-9]{13}")]
    public string? RegistrationNumber { get; set; }

    [RegularExpression(@"[0-9]{10}")]
    public string? Phone { get; set; }

    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public string? Email { get; set; }

    public InstitutionalProperty? InstitutionalProperty { get; set; }
    public BuildingProperty? BuildingProperty { get; set; }

    public string? IdRector { get; set; }

}
