using DotNet2023.Domain.InstitutionStructure;

namespace DotNet2023.WebApi.Interfaces.InstitutionStructure;
public interface IGroupOfStudents
{
    ICollection<GroupOfStudents>? GetGroupOfStudents();
    ICollection<GroupOfStudents>? GetGroupOfStudentsBySpecialityCode(string code);
    ICollection<GroupOfStudents>? GetGroupOfStudentsByDepartment(string idDepartment);

    GroupOfStudents? GetGroupOfStudentstById(string IdGroupOfStudents);

    bool GroupOfStudentsExistsById(string IdGroupOfStudents);
    Task<bool> GroupOfStudentsExistsByIdAsync(string IdGroupOfStudents);

    bool CreateGroupOfStudents(GroupOfStudents groupOfStudents);
    bool UpdateGroupOfStudents(GroupOfStudents groupOfStudents);
    bool DeleteGroupOfStudents(GroupOfStudents groupOfStudents);
    bool Save();

    Task<bool> CreateGroupOfStudentsAsync(GroupOfStudents groupOfStudents);
    Task<bool> UpdateGroupOfStudentsAsync(GroupOfStudents groupOfStudents);
    Task<bool> DeleteGroupOfStudentsAsync(GroupOfStudents groupOfStudents);
    public Task<bool> SaveAsync();
}
