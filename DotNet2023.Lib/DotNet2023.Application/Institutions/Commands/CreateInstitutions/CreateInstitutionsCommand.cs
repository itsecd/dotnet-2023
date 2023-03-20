using DotNet2023.Domain.Organization;
using MediatR;

namespace DotNet2023.Application.Institutions.Commands.CreateInstitutions;

public class CreateInstitutionsCommand : IRequest
{
    public string IdInstitution { get; set; } = String.Empty;
    public string? FullName { get; set; }
    public string? Initials { get; set; }
    public string? LegalAddress { get; set; }

    public string? RegistrationNumber { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public InstitutionalProperty? InstitutionalProperty { get; set; }
    public BuildingProperty? BuildingProperty { get; set; }
}
