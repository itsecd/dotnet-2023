using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.InstitutionStructure;
public class DepartmentRepository : IDepartment
{
    private readonly DbContextWebApi _dbContext;
    public DepartmentRepository(DbContextWebApi dbContext) =>
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


    public bool DepartmentExistsById(string idDepartment) =>
        _dbContext.Departments
            .Any(x => x.Id == idDepartment);
    public async Task<bool> DepartmentExistsByIdAsync(string idDepartment) =>
        await _dbContext.Departments
            .AnyAsync(x => x.Id == idDepartment);


    public Department? GetDepartmentById(string idDepartment) =>
        _dbContext.Departments
            .FirstOrDefault(x => x.Id == idDepartment);
    public async Task<Department>? GetDepartmentByIdAsync(string idDepartment) =>
        await _dbContext.Departments
            .FirstOrDefaultAsync(x => x.Id == idDepartment);


    public ICollection<Department>? GetDepartments() =>
        _dbContext.Departments.ToList();
    public async Task<ICollection<Department>>? GetDepartmentsAsync() =>
        await _dbContext.Departments.ToListAsync();


    public ICollection<Department>? GetDepartmentsByFaculty(string idFaculty) =>
        _dbContext.Departments
        .Where(x => x.IdFaculty == idFaculty)
        .ToList();
    public async Task<ICollection<Department>>? GetDepartmentsByFacultyAsync(string idFaculty) =>
        await _dbContext.Departments
        .Where(x => x.IdFaculty == idFaculty)
        .ToListAsync();


    public ICollection<Department>? GetDepartmentsByInstitution(string idInstitution) =>
        _dbContext.Departments
        .Where(x => x.IdInstitute == idInstitution)
        .ToList();
    public async Task<ICollection<Department>>? GetDepartmentsByInstitutionAsync(string idInstitution) =>
        await _dbContext.Departments
        .Where(x => x.IdInstitute == idInstitution)
        .ToListAsync();


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
