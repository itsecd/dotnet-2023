using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.Organization;
using DotNet2023.Queries;

namespace DotNet2023.WebApi.Interfaces.Queries;
public interface IQueries
{
    public HigherEducationInstitution? GetInstitutionById(string id);

    public HigherEducationInstitution? GetInstitutionByInitials(string initials);

    public Speciality[]? GetPopularSpeciality();

    public HigherEducationInstitution[]? GetInstitutionsWithMaxDepartments();

    public Dictionary<string, int> GetOwnershipInstitutionAndGroup(InstitutionalProperty property);

    public ResponseUniversityStructByInitials? GetInstitutionStructByInitials(string initials);

    public ResponseUniversityStructByProperty[]? GetInstitutionStruct
        (InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty);

    public Task<HigherEducationInstitution>? GetInstitutionByIdAsync(string id);

    public Task<HigherEducationInstitution>? GetInstitutionByInitialsAsync(string initials);

    public Task<Speciality[]>? GetPopularSpecialityAsync();

    public Task<HigherEducationInstitution[]>? GetInstitutionsWithMaxDepartmentsAsync();

    public Task<Dictionary<string, int>> GetOwnershipInstitutionAndGroupAsync(InstitutionalProperty property);

    public Task<ResponseUniversityStructByInitials>? GetInstitutionStructByInitialsAsync(string initials);

    public Task<ResponseUniversityStructByProperty[]>? GetInstitutionStructAsync
        (InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty);
}
