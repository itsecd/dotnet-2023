namespace Department;
public class Course
{
    public string CourseType { get; set; } = string.Empty;
    public int Semester { get; set; }
    public uint SemesterHours { get; set; }
    public Subject Subject { get; set; } = new Subject();
    public Group Group { get; set; } = new Group();
    public Teacher Teacher { get; set; } = new Teacher();
}
