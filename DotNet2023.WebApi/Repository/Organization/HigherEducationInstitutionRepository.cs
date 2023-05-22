using DotNet2023.Domain.Organization;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.Organization;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.Organization;
public class HigherEducationInstitutionRepository : IHigherEducationInstitution
{
    private readonly DbContextWebApi _dbContext;
    public HigherEducationInstitutionRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;

    public bool CreateInstructon(HigherEducationInstitution institution)
    {
        _dbContext.Institutes.Add(institution);
        return Save();
    }
    public async Task<bool> CreateInstructonAsync(HigherEducationInstitution institution)
    {
        await _dbContext.Institutes.AddAsync(institution);
        return await SaveAsync();
    }


    public bool DeleteInstructon(HigherEducationInstitution institution)
    {
        _dbContext.Institutes.Remove(institution);
        return Save();
    }
    public async Task<bool> DeleteInstructonAsync(HigherEducationInstitution institution)
    {
        _dbContext.Institutes.Remove(institution);
        return await SaveAsync();
    }


    public HigherEducationInstitution? GetInstitution(string idInstitution) =>
        _dbContext.Institutes
        .FirstOrDefault(institution => institution.Id == idInstitution);
    public async Task<HigherEducationInstitution>? GetInstitutionAsync
        (string idInstitution) =>
        await _dbContext.Institutes
        .FirstOrDefaultAsync(institution => institution.Id == idInstitution);


    public ICollection<HigherEducationInstitution> GetInstitutions() =>
        _dbContext.Institutes.ToList();
    public async Task<ICollection<HigherEducationInstitution>> GetInstitutionsAsync() =>
        await _dbContext.Institutes.ToListAsync();


    public bool InstitutionExists(string idInstitution) =>
        _dbContext.Institutes
        .Any(x => x.Id == idInstitution);
    public async Task<bool> InstitutionExistsAsync(string idInstitution) =>
        await _dbContext.Institutes
        .AnyAsync(x => x.Id == idInstitution);


    public bool InstructonExistsByInitials(string initials) =>
        _dbContext.Institutes
        .Any(x => x.Initials == initials);
    public async Task<bool> InstructonExistsByInitialsAsync(string initials) =>
        await _dbContext.Institutes
        .AnyAsync(x => x.Initials == initials);


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


    public bool UpdateInstructon(HigherEducationInstitution institution)
    {
        _dbContext.Institutes.Update(institution);
        return Save();
    }
    public async Task<bool> UpdateInstructonAsync(HigherEducationInstitution institution)
    {
        _dbContext.Institutes.Update(institution);
        return await SaveAsync();
    }
}
