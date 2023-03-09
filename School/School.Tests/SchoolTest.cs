using School.Classes;
namespace School.Tests;

public class SchoolTest
{
    /// <summary>
    /// Creating a list of 8 ratings
    /// </summary>
    private List<Grade> CreateListGrades()
    {
        var students = CreateListStudents();
        var subject = CreateListSubjects();
        return new List<Grade>()
        {
            new Grade(16, subject[0], students[0], 5, DateTime.Parse("2022/10/10")),
            new Grade(1, subject[0], students[1], 5, DateTime.Parse("2022/10/10")),
            new Grade(2, subject[0], students[2], 5, DateTime.Parse("2022/10/10")),
            new Grade(3, subject[0], students[3], 5, DateTime.Parse("2022/10/10")),
            new Grade(4, subject[0], students[4], 5, DateTime.Parse("2022/10/10")),

            new Grade(5, subject[0], students[5], 2, DateTime.Parse("2022/12/12")),
            new Grade(6, subject[0], students[6], 3, DateTime.Parse("2022/12/12")),
            new Grade(7, subject[0], students[7], 4, DateTime.Parse("2022/12/12")),

            new Grade(8, subject[1], students[0], 3, DateTime.Parse("2022/10/13")),
            new Grade(9, subject[1], students[1], 4, DateTime.Parse("2022/10/13")),
            new Grade(10, subject[1], students[2], 4, DateTime.Parse("2022/10/13")),
            new Grade(11, subject[1], students[3], 4, DateTime.Parse("2022/10/13")),
            new Grade(12, subject[1], students[4], 4, DateTime.Parse("2022/10/12")),
            new Grade(13, subject[0], students[5], 1, DateTime.Parse("2022/10/13")),
            new Grade(14, subject[0], students[6], 1, DateTime.Parse("2022/10/13")),
            new Grade(15, subject[0], students[7], 1, DateTime.Parse("2022/10/13"))
        };
    }
    /// <summary>
    /// Creating a list of 8 items
    /// </summary>
    /// <returns></returns>
    private List<Subject> CreateListSubjects()
    {
        return new List<Subject>()
        {
            new Subject(1, "Philosophy", 2008,null),
            new Subject(2, "Physics", 2020,null),
            new Subject(3, "Programming", 2023,null),
            new Subject(4, "Mathematical analysis", 2008,null),
            new Subject(5, "History", 2001,null),
            new Subject(6, "fundamentals of life safety", 2008,null),
            new Subject(7, "Literature", 2008,null),
            new Subject(8, "Russian language", 2007,null)
        };
    }
    /// <summary>
    /// Creating a list of 8 students
    /// </summary>
    /// <returns></returns>
    private List<Student> CreateListStudents()
    {
        return new List<Student>()
        {
            new Student(1, "Marizov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2001/1/10"),null),
            new Student(2, "Voronin", "Konstantin", "Borisovich", "2001-11111", new Class(2, 10, 'b',null), DateTime.Parse("2000/1/11"),null),
            new Student(3, "Arshavin", "Andrey", "Alexeevich", "2001-11111", new Class(4, 9, 'c',null), DateTime.Parse("2001/2/16"),null),
            new Student(4, "Putilin", "Nikita", "Alexeevich", "2001-11111", new Class(3, 10, 'a',null), DateTime.Parse("1999/1/10"),null),
            new Student(5, "Sazonov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2001/2/10"),null),
            new Student(6, "Yarmakov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2003/4/10"),null),
            new Student(7, "Kareglazov", "Alexey", "Alexeevich", "2001-11111", new Class(5, 8, 'c',null), DateTime.Parse("2005/11/10"),null),
            new Student(8, "Privetov", "Alexey", "Alexeevich", "2001-11111", new Class(6, 9, 'd',null), DateTime.Parse("2008/1/10"),null)
        };
    }

    /// <summary>
    /// 1) Output information about all items. Checking for the number of items
    /// </summary>
    [Fact]
    public void AllSubjectTest()
    {
        var subjects = CreateListSubjects();
        Assert.Equal(8, subjects.Count);
    }

    /// <summary>
    /// 2) Output information about all students in the specified class, arrange by name.
    /// </summary>
    [Fact]
    public void AllStudentClassTest()
    {
        var students = CreateListStudents();
        var @class = new Class(1, 11, 'a', null);

        var needStudents = (from student in students
                            where student.Class != null && student.Class.Equals(@class)
                            orderby student.LastName, student.FirstName, student.Patronymic
                            select student).ToList();

        var result = new List<Student>
        {
            new Student(1, "Marizov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2001/1/10"),null),
            new Student(5, "Sazonov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2001/2/10"),null),
            new Student(6, "Yarmakov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2003/4/10"),null)
        };

        for (var i = 0; i < result.Count; i++)
        {
            Assert.True(result[i].Equals(needStudents.ElementAt(i)));
        }
    }

    /// <summary>
    /// 3) Output information about all students who received grades on the specified day.
    /// </summary>
    [Fact]
    public void StudentGradesDayTest()
    {
        var grades = CreateListGrades();

        var info = (from grade in grades
                    where grade.Date == DateTime.Parse("2022/10/10")
                    select grade.Student).ToList();

        Assert.Equal(5, info.Count);
    }

    /// <summary>
    /// 4) Bring out the top 5 students by average score.
    /// </summary>
    [Fact]
    public void TopStudentsAvrMarkTest()
    {
        var grades = CreateListGrades();

        var topFive = (from grade in grades
                       group grade by grade.Student into g
                       select new
                       {
                           Student = g.Key,
                           Marks = g.Average(s => s.Mark)
                       }).Take(5).OrderByDescending(s => s.Marks).ThenBy(s => s.Student.FirstName).ToList();

        var result = new List<Student>
        {
            new Student(3, "Arshavin", "Andrey", "Alexeevich", "2001-11111", new Class(4, 9, 'c',null), DateTime.Parse("2001/2/16"),null),
            new Student(4, "Putilin", "Nikita", "Alexeevich", "2001-11111", new Class(3, 10, 'a',null), DateTime.Parse("1999/1/10"),null),
            new Student(5, "Sazonov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2001/2/10"),null),
            new Student(2, "Voronin", "Konstantin", "Borisovich", "2001-11111", new Class(2, 10, 'b',null), DateTime.Parse("2000/1/11"),null),
            new Student(1,"Marizov", "Alexey", "Alexeevich", "2001-11111", new Class(1, 11, 'a',null), DateTime.Parse("2001/1/10"),null)
        };

        for (var i = 0; i < result.Count; i++)
        {
            Assert.True(result[i].Equals(topFive.ElementAt(i).Student));
        }
    }

    /// <summary>
    /// 5) Output students with the maximum average score for the specified period.
    /// </summary>
    [Fact]
    public void MaxAvrScorePeriodTest()
    {
        var grades = CreateListGrades();

        var averageMarks =
            (from grade in grades
            where grade.Date >= DateTime.Parse("2022/10/10") && grade.Date <= DateTime.Parse("2022/10/14")
            group grade by grade.Student into g
            select new
            {
              Student = g.Key,
              Marks = g.Average(s => s.Mark)
            }).ToList();

        var maxMark = averageMarks.Max(x => x.Marks);
        var numStudents = averageMarks.Count(x => x.Marks.Equals(maxMark));
        Assert.True(numStudents == 4);
    }

    /// <summary>
    /// 6) Output information about the minimum, average and maximum score for each subject.
    /// </summary>
    [Fact]
    public void MinMaxAvrMarkSubjectTest()
    {
        var grades = CreateListGrades();

        var infoMarks = (from grade in grades
                         group grade by grade.Subject into g
                         select new
                         {
                             Min = g.Min(s => s.Mark),
                             Max = g.Max(s => s.Mark),
                             Average = g.Average(s => s.Mark)
                         }).ToList();

        Assert.Equal(3, infoMarks[1].Min);
        Assert.Equal(4, infoMarks[1].Max);
        Assert.Equal(3.8, infoMarks[1].Average);
    }
}