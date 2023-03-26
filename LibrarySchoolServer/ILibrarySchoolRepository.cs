using LibrarySchool;

namespace LibrarySchoolServer;
/// <summary>
/// Interface class LibrarySchoolRepository
/// </summary>
public interface ILibrarySchoolRepository
{
    /// <summary>
    /// Property list class in data
    /// </summary>
    List<ClassType> ClassTypes { get; }

    /// <summary>
    /// Property list mark in data
    /// </summary>
    List<Mark> Marks { get; }

    /// <summary>
    /// Property list students in data
    /// </summary>
    List<Student> Students { get; }

    /// <summary>
    /// Property list subject in data
    /// </summary>
    List<Subject> Subjects { get; }
}