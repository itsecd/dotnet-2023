using Microsoft.EntityFrameworkCore;

namespace Department.Domain;
public class DepartmentDbContext : DbContext
{
    /// <summary>
    /// Collection of groups
    /// </summary>
    public DbSet<Group>? Groups { get; set; }

    /// <summary>
    /// Collection of teachers
    /// </summary>
    public DbSet<Teacher>? Teachers { get; set; }

    /// <summary>
    /// Collection of subjects
    /// </summary>
    public DbSet<Subject>? Subjects { get; set; }

    /// <summary>
    /// Collection of courses
    /// </summary>
    public DbSet<Course>? Courses { get; set; }

    public DepartmentDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Insetring data into database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var group1 = new Group { Id = 6311, StudentAmount = 25, EducationType = "D" };
        var group2 = new Group { Id = 6312, StudentAmount = 16, EducationType = "D" };
        var group3 = new Group { Id = 6295, StudentAmount = 25, EducationType = "V" };

        modelBuilder.Entity<Group>().HasData(new List<Group> { group1, group2, group3 });

        var subject1 = new Subject { Id = 1, Name = "Математический анализ", Semester = 1 };
        var subject2 = new Subject { Id = 2, Name = "Промышленное программирование", Semester = 6 };
        var subject3 = new Subject { Id = 3, Name = "Статистический анализ данных", Semester = 5 };
        var subject4 = new Subject { Id = 4, Name = "Дискретная математика", Semester = 2 };
        var subject5 = new Subject { Id = 5, Name = "Физкультура", Semester = 3 };

        modelBuilder.Entity<Subject>().HasData(new List<Subject> { subject1, subject2, subject3, subject4, subject5 });

        var teacher1 = new Teacher { Id = 1, FullName = "Максимова Людмила Александровна", Degree = "Профессор" };
        var teacher2 = new Teacher { Id = 2, FullName = "Шашкова Татьяна Якубовна", Degree = "Доцент" };
        var teacher3 = new Teacher { Id = 3, FullName = "Аввакумова Тамара Николаевна", Degree = "Профессор" };

        modelBuilder.Entity<Teacher>().HasData(new List<Teacher> { teacher1, teacher2, teacher3 });

        var course1 = new Course { Id = 1, SubjectName = "Математический анализ", SubjectId = 1, CourseType = "Лекции", SemesterHours = 256, GroupId = 6312, TeachersName = "Максимова Людмила Александровна", TeacherId = 1 };
        var course2 = new Course { Id = 2, SubjectName = "Промышленное программирование", SubjectId = 2, CourseType = "Курсовой проект", SemesterHours = 123, GroupId = 6311, TeachersName = "Шашкова Татьяна Якубовна", TeacherId = 2 };
        var course3 = new Course { Id = 3, SubjectName = "Физкультура", CourseType = "Курсовой проект", SubjectId = 5, SemesterHours = 14, GroupId = 6295, TeachersName = "Максимова Людмила Александровна", TeacherId = 1 };
        var course4 = new Course { Id = 4, SubjectName = "Математический анализ", SubjectId = 1, CourseType = "Лекции", SemesterHours = 500, GroupId = 6311, TeachersName = "Шашкова Татьяна Якубовна", TeacherId = 2 };

        modelBuilder.Entity<Course>().HasData(new List<Course> { course1, course2, course3 });
    }
}
