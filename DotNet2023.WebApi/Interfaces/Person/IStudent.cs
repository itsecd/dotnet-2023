using DotNet2023.Domain.Person;

namespace DotNet2023.WebApi.Interfaces.Person;
public interface IStudent
{
    ICollection<Student>? GetStudents();
    ICollection<Student>? GetStudentsByGroupOfStudents(string idGroupOfStudent);

    Student? GetStudentById(string idStudent);

    Task<ICollection<Student>>? GetStudentsAsync();
    Task<ICollection<Student>>? GetStudentsByGroupOfStudentsAsync(string idGroupOfStudent);

    Task<Student>? GetStudentByIdAsync(string idStudent);

    bool StudentExistsById(string idStudent);
    Task<bool> StudentExistsByIdAsync(string idStudent);

    bool CreateStudent(Student student);
    bool UpdateStudent(Student student);
    bool DeleteStudent(Student student);
    bool Save();

    Task<bool> CreateStudentAsync(Student student);
    Task<bool> UpdateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(Student student);
    public Task<bool> SaveAsync();
}
