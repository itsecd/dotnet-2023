using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.InstitutionStructure;
public class DepartmenRepository : IDepartment
{
    private readonly DbContextWebApi _dbContext;
    public DepartmenRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;

    public bool CreateDepartment(Department department)
    {
        _dbContext.Departments.Add(department);
        return Save();
    }

    public async Task<bool> CreateDepartmentAsync(Department department)
    {
        await _dbContext.Departments.AddAsync(department);
        return await SaveAsync();
    }

    public bool DeleteDepartment(Department department)
    {
        _dbContext.Departments.Remove(department);
        return Save();
    }

    public async Task<bool> DeleteDepartmentAsync(Department department)
    {
        _dbContext.Departments.Remove(department);
        return await SaveAsync();
    }

    public bool DepartmentExistsById(string idDepartment)
    {
        return _dbContext.Departments
            .Any(x=>x.Id == idDepartment);
    }

    public async Task<bool> DepartmentExistsByIdAsync(string idDepartment)
    {
        return await _dbContext.Departments
            .AnyAsync(x => x.Id == idDepartment);
    }

    public Department? GetDepartmentById(string idDepartment)
    {
        return _dbContext.Departments
            .FirstOrDefault(x => x.Id == idDepartment);
    }

    public ICollection<Department>? GetDepartments()
    {
        return _dbContext.Departments.ToList();
    }

    public ICollection<Department>? GetDepartmentsByFaculty(string idFaculty)
    {
        return _dbContext.Departments
            .Where(x => x.IdFaculty == idFaculty)
            .ToList();
    }

    public ICollection<Department>? GetDepartmentsByInstitution(string idInstitution)
    {
        return _dbContext.Departments
            .Where(x => x.IdInstitute == idInstitution)
            .ToList();
    }

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

    public bool UpdateDepartment(Department department)
    {
        _dbContext.Departments.Update(department);
        return Save();
    }

    public async Task<bool> UpdateDepartmentAsync(Department department)
    {
        _dbContext.Departments.Update(department);
        return await SaveAsync();
    }
}
