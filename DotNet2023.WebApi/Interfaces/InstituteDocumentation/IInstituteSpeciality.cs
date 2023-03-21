using DotNet2023.Domain.InstituteDocumentation;

namespace DotNet2023.WebApi.Interfaces.InstituteDocumentation;
public interface IInstituteSpeciality
{
    ICollection<InstituteSpeciality>? GetInstituteSpecialities();
    ICollection<InstituteSpeciality>? GetInstituteSpecialitiesByCode(
        string code);
    ICollection<InstituteSpeciality>? GetInstituteSpecialitiesByInstitution(
        string idInstitution);

    InstituteSpeciality? GetInstituteSpeciality(string code, string idInstitution);

    bool InstituteSpecialityExistsByCode(string code);
    bool InstituteSpecialityExists(string code, string idInstitution);
    Task<bool> InstituteSpecialityExistsByCodeAsync(string code);
    Task<bool> InstituteSpecialityExistsAsync(string code, string idInstitution);



    bool CreateInstituteSpeciality(InstituteSpeciality instituteSpeciality);
    bool UpdateInstituteSpeciality(InstituteSpeciality instituteSpeciality);
    bool DeleteInstituteSpeciality(InstituteSpeciality instituteSpeciality);
    bool Save();

    Task<bool> CreateInstituteSpecialityAsync(InstituteSpeciality instituteSpeciality);
    Task<bool> UpdateInstituteSpecialityAsync(InstituteSpeciality instituteSpeciality);
    Task<bool> DeleteInstituteSpecialityAsync(InstituteSpeciality instituteSpeciality);
    public Task<bool> SaveAsync();
}
