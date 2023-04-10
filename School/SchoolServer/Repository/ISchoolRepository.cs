using School.Classes;
namespace SchoolServer.Repository

{
    public interface ISchoolRepository
    {
        List<Class> Classes { get; }
        List<Grade> Grades { get; }
        List<Student> Students { get; }
        List<Subject> Subjects { get; }
    }
}