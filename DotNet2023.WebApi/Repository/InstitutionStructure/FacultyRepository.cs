using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.InstitutionStructure;
public class FacultyRepository : IFaculty
{
    private readonly DbContextWebApi _dbContext;
    public FacultyRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;

    public bool CreateFaculty(Faculty faculty)
    {
        _dbContext.Faculties.Add(faculty);
        return Save();
    }

    public async Task<bool> CreateFacultyAsync(Faculty faculty)
    {
        await _dbContext.Faculties.AddAsync(faculty);
        return await SaveAsync();
    }

    public bool DeleteFaculty(Faculty faculty)
    {
        _dbContext.Faculties.Remove(faculty);
        return Save();
    }
    public async Task<bool> DeleteFacultyAsync(Faculty faculty)
    {
        _dbContext.Faculties.Remove(faculty);
        return await SaveAsync();
    }

    public async Task<bool> FacultyExistsByIdAsync(string IdFaculty) =>
        await _dbContext.Faculties
        .AnyAsync(x => x.Id == IdFaculty);

    public bool FacultytExistsById(string IdFaculty) => 
        _dbContext.Faculties
        .Any(x => x.Id == IdFaculty);

    public ICollection<Faculty>? GetFaculties() =>
        _dbContext.Faculties.ToList();

    public ICollection<Faculty>? GetFacultiesByInstitution(string idInstitution) =>
         _dbContext.Faculties.Where(x => x.IdInstitute == idInstitution)
        .ToList();

    public Faculty? GetFacultyById(string IdFaculty) =>
        _dbContext.Faculties.FirstOrDefault(x => x.Id == IdFaculty);

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

    public bool UpdateFaculty(Faculty faculty)
    {
        _dbContext.Faculties.Update(faculty);
        return Save();
    }

    public async Task<bool> UpdateFacultyAsync(Faculty faculty)
    {
        _dbContext.Faculties.Update(faculty);
        return await SaveAsync();
    }
}