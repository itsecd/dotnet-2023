using Microsoft.EntityFrameworkCore;

namespace Department.Domain;

/// <summary>
/// DbContext for creating a database
/// </summary>
public class DepartmentDbContext : DbContext
{
    /// <summary>
    /// Collection of groups
    /// </summary>
    public DbSet<Group> Groups { get; set; }

    /// <summary>
    /// Collection of teachers
    /// </summary>
    public DbSet<Teacher> Teachers { get; set; }

    /// <summary>
    /// Collection of subjects
    /// </summary>
    public DbSet<Subject> Subjects { get; set; }

    /// <summary>
    /// Collection of courses
    /// </summary>
    public DbSet<Course> Courses { get; set; }

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

        var group1 = new Group { Id = 1, GroupNumber = 6311, StudentAmount = 25, EducationType = "D" };
        var group2 = new Group { Id = 2, GroupNumber = 6312, StudentAmount = 16, EducationType = "D" };
        var group3 = new Group { Id = 3, GroupNumber = 6295, StudentAmount = 25, EducationType = "V" };

        var subject1 = new Subject { Id = 1, Name = "Math", Semester = 1 };
        var subject2 = new Subject { Id = 2, Name = "Industrial programming", Semester = 6 };
        var subject3 = new Subject { Id = 3, Name = "Data analytics", Semester = 5 };
        var subject4 = new Subject { Id = 4, Name = "Algebra", Semester = 2 };
        var subject5 = new Subject { Id = 5, Name = "Physics", Semester = 3 };

        var teacher1 = new Teacher { Id = 1, FullName = "Maksimova Lyudmila", Degree = "Professor" };
        var teacher2 = new Teacher { Id = 2, FullName = "Shashkova Tatiana", Degree = "Assistant professor" };
        var teacher3 = new Teacher { Id = 3, FullName = "Belov Alexander", Degree = "Professor" };

        var course1 = new Course { Id = 1, SubjectName = "Math", SubjectId = 1, CourseType = "Lectures", SemesterHours = 256, GroupId = 2, TeachersName = "Maksimova Lyudmila", TeacherId = 1 };
        var course2 = new Course { Id = 2, SubjectName = "Industrial programming", SubjectId = 2, CourseType = "Course project", SemesterHours = 123, GroupId = 1, TeachersName = "Shashkova Tatiana", TeacherId = 2 };
        var course3 = new Course { Id = 3, SubjectName = "Physics", CourseType = "Course project", SubjectId = 5, SemesterHours = 14, GroupId = 3, TeachersName = "Maksimova Lyudmila", TeacherId = 1 };
        var course4 = new Course { Id = 4, SubjectName = "Math", SubjectId = 1, CourseType = "Lectures", SemesterHours = 500, GroupId = 1, TeachersName = "Shashkova Tatiana", TeacherId = 2 };

        modelBuilder.Entity<Teacher>().HasData(new List<Teacher> { teacher1, teacher2, teacher3 });
        modelBuilder.Entity<Subject>().HasData(new List<Subject> { subject1, subject2, subject3, subject4, subject5 });
        modelBuilder.Entity<Group>().HasData(new List<Group> { group1, group2, group3 });
        modelBuilder.Entity<Course>().HasData(new List<Course> { course1, course2, course3, course4 });
    }
}
