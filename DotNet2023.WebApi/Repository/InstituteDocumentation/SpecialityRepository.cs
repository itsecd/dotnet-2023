using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.InstituteDocumentation;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.InstituteDocumentation;
public class SpecialityRepository : ISpeciality
{
    private readonly DbContextWebApi _dbContext;
    public SpecialityRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;


    public bool CreateSpeciality(Speciality speciality)
    {
        _dbContext.Specialties.Add(speciality);
        return Save();
    }
    public async Task<bool> CreateSpecialityAsync(Speciality speciality)
    {
        await _dbContext.Specialties.AddAsync(speciality);
        return await SaveAsync();
    }


    public bool DeleteSpeciality(Speciality speciality)
    {
        _dbContext.Specialties.Remove(speciality);
        return Save();
    }
    public async Task<bool> DeleteSpecialityAsync(Speciality speciality)
    {
        _dbContext.Specialties.Remove(speciality);
        return await SaveAsync();
    }


    public ICollection<Speciality>? GetSpecialities() =>
        _dbContext.Specialties.ToList();
    public async Task<ICollection<Speciality>>? GetSpecialitiesAsync() =>
        await _dbContext.Specialties.ToListAsync();

    public Speciality? GetSpeciality(string code) =>
        _dbContext.Specialties
        .FirstOrDefault(x => x.Code == code);
    public async Task<Speciality>? GetSpecialityAsync(string code) =>
        await _dbContext.Specialties
        .FirstOrDefaultAsync(x => x.Code == code);


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


    public bool SpecialityExists(string code) =>
        _dbContext.Specialties
        .Any(x => x.Code == code);
    public async Task<bool> SpecialityExistsAsync(string code) =>
        await _dbContext.Specialties
        .AnyAsync(x => x.Code == code);


    public bool UpdateSpeciality(Speciality speciality)
    {
        _dbContext.Specialties.Update(speciality);
        return Save();
    }
    public async Task<bool> UpdateSpecialityAsync(Speciality speciality)
    {
        _dbContext.Specialties.Update(speciality);
        return await SaveAsync();
    }
}
