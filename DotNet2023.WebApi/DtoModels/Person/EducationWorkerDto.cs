using System.ComponentModel.DataAnnotations;

namespace DotNet2023.WebApi.DtoModels.Person;
public class EducationWorkerDto
{
    public string Id { get; set; } 
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }

    public DateTime? BirthDay { get; set; }

    [RegularExpression(@"\\S+@\\S+\\.\\S+$")]
    public string? Email { get; set; }

    [RegularExpression(@"[0-9]{10}")]
    public string? Phone { get; set; }

    public string? ScienceDegree { get; set; }
    public string? Rank { get; set; }

    public string? IdOrganization { get; set; }
    public string? JobTitle { get; set; }
    public double? Salary { get; set; }
}
