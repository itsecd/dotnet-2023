using DotNet2023.Domain.Person;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.Person;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.Person;
public class StudentRepository : IStudent
{
    private readonly DbContextWebApi _dbContext;
    public StudentRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;

    public bool CreateStudent(Student student)
    {
        _dbContext.Students.Add(student);
        return Save();
    }

    public async Task<bool> CreateStudentAsync(Student student)
    {
        await _dbContext.Students.AddAsync(student);
        return await SaveAsync();
    }

    public bool DeleteStudent(Student student)
    {
        _dbContext.Students.Remove(student);
        return Save();
    }

    public async Task<bool> DeleteStudentAsync(Student student)
    {
        _dbContext.Students.Remove(student);
        return await SaveAsync();
    }

    public Student? GetStudentById(string IdStudent) =>
        _dbContext.Students
        .FirstOrDefault(x => x.Id == IdStudent);

    public ICollection<Student>? GetStudents() =>
        _dbContext.Students.ToList();

    public ICollection<Student>? GetStudentsByGroupOfStudents(
        string idGroupOfStudent) =>
        _dbContext.Students
        .Where(x => x.IdGroup == idGroupOfStudent)
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

    public bool StudentExistsById(string idStudent) =>
        _dbContext.Students
        .Any(x => x.Id == idStudent);

    public async Task<bool> StudentExistsByIdAsync(string idStudent) =>
        await _dbContext.Students
        .AnyAsync(x => x.Id == idStudent);

    public bool UpdateStudent(Student student)
    {
        _dbContext.Students.Update(student);
        return Save();
    }

    public async Task<bool> UpdateStudentAsync(Student student)
    {
        _dbContext.Students.Update(student);
        return await SaveAsync();
    }
}
