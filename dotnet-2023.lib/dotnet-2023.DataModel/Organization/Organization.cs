using System.ComponentModel.DataAnnotations;

namespace dotnet_2023.DataModel.Organization;

public class Organization
{
    [Required]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    public string? FullName { get; set; }
    public string? Initials { get; set; }

    // TODO: create a regular expression type of "Country. Region. City. Address"
    public string? LegalAddress { get; set; }


    [RegularExpression(@"[0-9]{13}")]
    public string? RegistrationNumber { get; set; }

    [RegularExpression(@"[0-9]{11}")]
    public string? Phone { get; set; }

    [RegularExpression(@"\\S+@\\S+\\.\\S+$")]
    public string? Email { get; set; }
}
