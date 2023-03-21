using DotNet2023.Domain.Person;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.Person;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.Person;
public class EducationWorkerRepository : IEducationWorker
{
    private readonly DbContextWebApi _dbContext;
    public EducationWorkerRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;

    public bool CreateEducationWorker(EducationWorker educationWorker)
    {
        _dbContext.EducationWorker.Add(educationWorker);
        return Save();
    }

    public async Task<bool> CreateEducationWorkerAsync(EducationWorker educationWorker)
    {
        await _dbContext.EducationWorker.AddAsync(educationWorker);
        return await SaveAsync();
    }

    public bool DeleteEducationWorker(EducationWorker educationWorker)
    {
        _dbContext.EducationWorker.Remove(educationWorker);
        return Save();
    }

    public async Task<bool> DeleteEducationWorkerAsync(EducationWorker educationWorker)
    {
        _dbContext.EducationWorker.Remove(educationWorker);
        return await SaveAsync();
    }

    public bool EducationWorkerExistsById(string IdEducationWorker) =>
        _dbContext.EducationWorker
        .Any(x=>x.Id == IdEducationWorker);

    public async Task<bool> EducationWorkerExistsByIdAsync(
        string IdEducationWorker) =>
        await _dbContext.EducationWorker
        .AnyAsync(x => x.Id == IdEducationWorker);

    public ICollection<EducationWorker>? GetEducationWorkers() =>
        _dbContext.EducationWorker.ToList();

    public EducationWorker? GetEducationWorkerById(string IdEducationWorker) =>
        _dbContext.EducationWorker
        .FirstOrDefault(x => x.Id == IdEducationWorker);

    public ICollection<EducationWorker>? GetEducationWorkerByInstitution(string idInstitution) =>
        _dbContext.EducationWorker
        .Where(x => x.IdOrganization == idInstitution)
        .ToList();

    public bool Save()
    {
        var saved = _dbContext.SaveChanges();
        return saved > 0 ? true : false;
    }

    public async Task<bool> SaveAsync()
    {
        var saved = await _dbContext.SaveChangesAsync();
        return saved > 0 ? true : false;
    }

    public bool UpdateEducationWorker(EducationWorker educationWorker)
    {
        _dbContext.EducationWorker.Update(educationWorker);
        return Save();
    }

    public async Task<bool> UpdateEducationWorkerAsync(EducationWorker educationWorker)
    {
        _dbContext.EducationWorker.Update(educationWorker);
        return await SaveAsync();
    }
}
