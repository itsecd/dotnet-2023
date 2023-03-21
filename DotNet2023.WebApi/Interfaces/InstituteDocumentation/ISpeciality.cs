using DotNet2023.Domain.InstituteDocumentation;

namespace DotNet2023.WebApi.Interfaces.InstituteDocumentation;
public interface ISpeciality
{
    ICollection<Speciality>? GetSpecialities();
    Speciality? GetSpeciality(string code);

    bool SpecialityExists(string code);
    Task<bool> SpecialityExistsAsync(string code);


    bool CreateSpeciality(Speciality speciality);
    bool UpdateSpeciality(Speciality speciality);
    bool DeleteSpeciality(Speciality speciality);
    bool Save();

    Task<bool> CreateSpecialityAsync(Speciality speciality);
    Task<bool> UpdateSpecialityAsync(Speciality speciality);
    Task<bool> DeleteSpecialityAsync(Speciality speciality);
    public Task<bool> SaveAsync();
}
