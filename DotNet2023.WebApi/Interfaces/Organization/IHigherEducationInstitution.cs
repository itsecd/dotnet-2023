using DotNet2023.Domain.Organization;

namespace DotNet2023.WebApi.Interfaces.Organization;
public interface IHigherEducationInstitution
{
    ICollection<HigherEducationInstitution> GetInstitutions();
    HigherEducationInstitution? GetInstitution(string idInstitution);
    Task<HigherEducationInstitution>? GetInstitutionAsync(string idInstitution);
    bool InstitutionExists(string idInstitution);
    Task<bool> InstitutionExistsAsync(string idInstitution);

    bool InstructonExistsByInitials(string initials);
    Task<bool> InstructonExistsByInitialsAsync(string initials);

    bool CreateInstructon(HigherEducationInstitution institution);
    bool UpdateInstructon(HigherEducationInstitution institution);
    bool DeleteInstructon(HigherEducationInstitution institution);
    bool Save();

    // TODO create async methods
    Task<bool> CreateInstructonAsync(HigherEducationInstitution institution);
    Task<bool> UpdateInstructonAsync(HigherEducationInstitution institution);
    Task<bool> DeleteInstructonAsync(HigherEducationInstitution institution);
    public Task<bool> SaveAsync();

}