using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.InstituteDocumentation;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.InstituteDocumentation;
public class InstituteSpecialityRepository : IInstituteSpeciality
{
    private readonly DbContextWebApi _dbContext;
    public InstituteSpecialityRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;

    public bool CreateInstituteSpeciality(InstituteSpeciality instituteSpeciality)
    {
        _dbContext.InstituteSpecialties.Add(instituteSpeciality);
        return Save();
    }

    public async Task<bool> CreateInstituteSpecialityAsync(InstituteSpeciality instituteSpeciality)
    {
        await _dbContext.InstituteSpecialties.AddAsync(instituteSpeciality);
        return await SaveAsync();
    }

    public bool DeleteInstituteSpeciality(InstituteSpeciality instituteSpeciality)
    {
        _dbContext.InstituteSpecialties.Remove(instituteSpeciality);
        return Save();
    }

    public async Task<bool> DeleteInstituteSpecialityAsync(InstituteSpeciality instituteSpeciality)
    {
        _dbContext.InstituteSpecialties.Remove(instituteSpeciality);
        return await SaveAsync();
    }

    public ICollection<InstituteSpeciality>? GetInstituteSpecialities() =>
        _dbContext.InstituteSpecialties.ToList();

    public ICollection<InstituteSpeciality>? GetInstituteSpecialitiesByCode
        (string code) =>
        _dbContext.InstituteSpecialties
        .Where(x => x.IdSpeciality == code)
        .ToList();

    public ICollection<InstituteSpeciality>? GetInstituteSpecialitiesByInstitution
        (string idInstitution)=>
        _dbContext.InstituteSpecialties
        .Where(x => x.IdHigherEducationInstitution == idInstitution)
        .ToList();

    public InstituteSpeciality? GetInstituteSpeciality
        (string code, string idInstitution) =>
        _dbContext.InstituteSpecialties
        .FirstOrDefault(x => x.IdHigherEducationInstitution == idInstitution &&
        x.IdSpeciality == code);

    public bool InstituteSpecialityExistsByCode(string code) =>
        _dbContext.InstituteSpecialties
        .Any(x => x.IdSpeciality == code);

    public async Task<bool> InstituteSpecialityExistsByCodeAsync(string code) =>
        await _dbContext.InstituteSpecialties
        .AnyAsync(x => x.IdSpeciality == code);

    public bool InstituteSpecialityExists(string code, string idInstitution) =>
        _dbContext.InstituteSpecialties
        .Any(x => x.IdSpeciality == code &&
        x.IdHigherEducationInstitution == idInstitution);

    public async Task<bool> InstituteSpecialityExistsAsync(string code, string idInstitution) =>
        await _dbContext.InstituteSpecialties
        .AnyAsync(x => x.IdSpeciality == code &&
        x.IdHigherEducationInstitution == idInstitution);

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

    public bool UpdateInstituteSpeciality(InstituteSpeciality instituteSpeciality)
    {
        _dbContext.InstituteSpecialties.Update(instituteSpeciality);
        return Save();
    }

    public async Task<bool> UpdateInstituteSpecialityAsync(InstituteSpeciality instituteSpeciality)
    {
        _dbContext.InstituteSpecialties.Update(instituteSpeciality);
        return await SaveAsync();
    }
}
