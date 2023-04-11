using School.Classes;

namespace SchoolServer.Repository;

/// <summary>
/// Интерфейс для класса ISchoolRepository
/// </summary>
public interface ISchoolRepository
{
    /// <summary>
    /// Список в котором хранятся классы
    /// </summary>
    List<Class> Classes { get; }
    /// <summary>
    /// Список в котором хранятся оценки
    /// </summary>
    List<Grade> Grades { get; }
    /// <summary>
    /// Список в котором хранятся студенты
    /// </summary>
    List<Student> Students { get; }
    /// <summary>
    /// Список в котором хранятся предметы
    /// </summary>
    List<Subject> Subjects { get; }
}
