using DotNet2023.Domain.Person;

namespace DotNet2023.WebApi.Interfaces.Person;
public interface IEducationWorker
{
    ICollection<EducationWorker>? GetEducationWorkers();
    ICollection<EducationWorker>? GetEducationWorkerByInstitution(string idInstitution);

    EducationWorker? GetEducationWorkerById(string IdEducationWorker);

    bool EducationWorkerExistsById(string IdEducationWorker);
    Task<bool> EducationWorkerExistsByIdAsync(string IdEducationWorker);

    bool CreateEducationWorker(EducationWorker educationWorker);
    bool UpdateEducationWorker(EducationWorker educationWorker);
    bool DeleteEducationWorker(EducationWorker educationWorker);
    bool Save();

    Task<bool> CreateEducationWorkerAsync(EducationWorker educationWorker);
    Task<bool> UpdateEducationWorkerAsync(EducationWorker educationWorker);
    Task<bool> DeleteEducationWorkerAsync(EducationWorker educationWorker);
    public Task<bool> SaveAsync();
}
