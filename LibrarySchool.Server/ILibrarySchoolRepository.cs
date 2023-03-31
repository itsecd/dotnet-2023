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

    /// <summary>
    /// Add new class
    /// </summary>
    /// <param name="classType"></param>
    void AddClass(ClassType classType);
    
    /// <summary>
    /// Add new mark
    /// </summary>
    /// <param name="mark"></param>
    void AddMark(Mark mark);

    /// <summary>
    /// Add new student
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    void AddStudent(Student student);
    double AverageMark(Student student);

    /// <summary>
    /// Change Class
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="newClass"></param>
    /// <returns></returns>
    bool ChangeClass(int classId, ClassType newClass);

    /// <summary>
    /// Change information of mark
    /// </summary>
    /// <param name="markId"></param>
    /// <param name="newMark"></param>
    /// <returns></returns>
    bool ChangeMark(int markId, Mark newMark);

    /// <summary>
    /// Change information of student
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newStudent"></param>
    /// <returns></returns>
    bool ChangeStudent(int id, Student newStudent);

    /// <summary>
    /// Delete student
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    bool DeleteClass(int classId);

    /// <summary>
    /// Delete mark by Id
    /// </summary>
    /// <param name="markId"></param>
    /// <returns></returns>
    bool DeleteMark(int markId);

    /// <summary>
    /// Delete student
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool DeleteStudent(int id);
}