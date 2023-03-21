using DotNet2023.Domain.InstitutionStructure;

namespace DotNet2023.WebApi.Interfaces.InstitutionStructure;
public interface IDepartment
{
    ICollection<Department>? GetDepartments();
    ICollection<Department>? GetDepartmentsByInstitution(string idInstitution);
    ICollection<Department>? GetDepartmentsByFaculty(string idFaculty);

    Department? GetDepartmentById(string idDepartment);

    bool DepartmentExistsById(string idDepartment);
    Task<bool> DepartmentExistsByIdAsync(string idDepartment);


    bool CreateDepartment(Department department);
    bool UpdateDepartment(Department department);
    bool DeleteDepartment(Department department);
    bool Save();

    Task<bool> CreateDepartmentAsync(Department department);
    Task<bool> UpdateDepartmentAsync(Department department);
    Task<bool> DeleteDepartmentAsync(Department department);
    public Task<bool> SaveAsync();
}
