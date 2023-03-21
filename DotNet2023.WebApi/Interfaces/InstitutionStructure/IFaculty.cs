using DotNet2023.Domain.InstitutionStructure;

namespace DotNet2023.WebApi.Interfaces.InstitutionStructure;
public interface IFaculty
{
    ICollection<Faculty>? GetFaculties();
    ICollection<Faculty>? GetFacultiesByInstitution(string idInstitution);

    Faculty? GetFacultyById(string IdFaculty);

    bool FacultytExistsById(string IdFaculty);
    Task<bool> FacultyExistsByIdAsync(string IdFaculty);


    bool CreateFaculty(Faculty faculty);
    bool UpdateFaculty(Faculty faculty);
    bool DeleteFaculty(Faculty faculty);
    bool Save();

    Task<bool> CreateFacultyAsync(Faculty faculty);
    Task<bool> UpdateFacultyAsync(Faculty faculty);
    Task<bool> DeleteFacultyAsync(Faculty faculty);
    public Task<bool> SaveAsync();
}
