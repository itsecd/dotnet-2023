using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySchool.Domain;

internal sealed class SeedDataGenerator
{
    public List<Subject> Subjects { get; set; } = null!;
    public List<Student> Students { get; set; } = null!;
    public List<ClassType> ClassTypes { get; set; } = null!;
    public List<Mark> Marks { get; set; } = null!;

    private void CreateListSubject()
    {
        Subjects = new List<Subject>()
        {
            new Subject() {SubjectId = 1, SubjectName = "Industrial programming", YearStudy = 2023},
            new Subject() {SubjectId = 2, SubjectName = "Database", YearStudy = 2023},
            new Subject() {SubjectId = 3, SubjectName = "Computer algebra", YearStudy = 2023},
            new Subject() {SubjectId = 4, SubjectName = "Information theory", YearStudy = 2022}
        };
    }
    private void CreateListStudent()
    {
        Students = new List<Student>()
        {
            new Student(){
                StudentId = 1,
                StudentName = "Pham Ngoc Hung",
                DateOfBirth = new DateTime(2000, 1, 4),
                Passport = "12343C",
                ClassId = 1
            },
            new Student(){
                StudentId = 2,
                StudentName = "La Hoang Anh",
                DateOfBirth = new DateTime(1998, 12, 12),
                Passport = "32342C",
                ClassId = 2
            },
            new Student()
            {
                StudentId= 3,
                StudentName = "Nguyen Van Hoang",
                DateOfBirth = new DateTime(1999, 6, 29),
                Passport = "32231C",
                ClassId = 3
            },
            new Student()
            {
                StudentId = 4,
                StudentName = "Kyle Roydon",
                DateOfBirth = new DateTime(1998, 4, 19),
                Passport = "12231C",
                ClassId = 2
            },
            new Student()
            {
                StudentId = 5,
                StudentName = "Nevil Mimi",
                DateOfBirth = new DateTime(2002, 3, 16),
                Passport = "11346C",
                ClassId = 1
            },
            new Student()
            {
                StudentId = 6,
                StudentName = "Mercia Gabriella",
                DateOfBirth = new DateTime(2001, 10, 22),
                Passport = "16431C",
                ClassId = 2
            },
            new Student()
            {
                StudentId = 7,
                StudentName = "Angelia Jerrard",
                DateOfBirth = new DateTime(2001, 5, 4),
                Passport = "23431C",
                ClassId = 1
            },
            new Student()
            {
                StudentId = 8,
                StudentName = "Happy Remy",
                DateOfBirth = new DateTime(2002, 7, 9),
                Passport = "12031C",
                ClassId = 3
            } };
    }

    private void CreateListClassType()
    {
        ClassTypes = new List<ClassType>()
        {
            new ClassType() {ClassId = 1, Number = 6311, Letter = "10-05-03D"},
            new ClassType() {ClassId = 2, Number = 6312, Letter = "10-05-03D"},
            new ClassType() {ClassId = 3, Number = 6411, Letter = "10-05-03D"}
        };
    }

    private void CreateListMark()
    {
        Marks = new List<Mark>(){
            new Mark() {MarkId = 1 , StudentId = 1, MarkValue = 3, SubjectId = 1, TimeReceive = new DateTime(2023, 6, 23)},
            new Mark() {MarkId = 2 , StudentId = 1, MarkValue = 5, SubjectId = 2, TimeReceive = new DateTime(2023, 6, 22)},
            new Mark() {MarkId = 3 , StudentId = 1, MarkValue = 5, SubjectId = 3, TimeReceive = new DateTime(2023, 6, 21)},
            new Mark() {MarkId = 4 , StudentId = 1, MarkValue = 4, SubjectId = 4, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 5 , StudentId = 2, MarkValue = 4, SubjectId = 1, TimeReceive = new DateTime(2023, 6, 22)},
            new Mark() {MarkId = 6 , StudentId = 2, MarkValue = 3, SubjectId = 2, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 7 , StudentId = 2, MarkValue = 4, SubjectId = 3, TimeReceive = new DateTime(2023, 6, 24)},
            new Mark() {MarkId = 8 , StudentId = 2, MarkValue = 3, SubjectId = 4, TimeReceive = new DateTime(2023, 6, 21)},
            new Mark() {MarkId = 9 , StudentId = 3, MarkValue = 4, SubjectId = 1, TimeReceive = new DateTime(2023, 6, 22)},
            new Mark() {MarkId = 10, StudentId = 3, MarkValue = 5, SubjectId = 2, TimeReceive = new DateTime(2023, 6, 21)},
            new Mark() {MarkId = 11, StudentId = 3, MarkValue = 4, SubjectId = 3, TimeReceive = new DateTime(2023, 6, 22)},
            new Mark() {MarkId = 12, StudentId = 3, MarkValue = 3, SubjectId = 4, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 13, StudentId = 4, MarkValue = 3, SubjectId = 1, TimeReceive = new DateTime(2023, 6, 23)},
            new Mark() {MarkId = 14, StudentId = 4, MarkValue = 2, SubjectId = 2, TimeReceive = new DateTime(2023, 6, 25)},
            new Mark() {MarkId = 15, StudentId = 4, MarkValue = 3, SubjectId = 3, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 16, StudentId = 4, MarkValue = 5, SubjectId = 4, TimeReceive = new DateTime(2023, 6, 27)},
            new Mark() {MarkId = 17, StudentId = 5, MarkValue = 5, SubjectId = 1, TimeReceive = new DateTime(2023, 6, 18)},
            new Mark() {MarkId = 18, StudentId = 5, MarkValue = 4, SubjectId = 2, TimeReceive = new DateTime(2023, 6, 24)},
            new Mark() {MarkId = 19, StudentId = 5, MarkValue = 3, SubjectId = 3, TimeReceive = new DateTime(2023, 6, 23)},
            new Mark() {MarkId = 20, StudentId = 5, MarkValue = 5, SubjectId = 4, TimeReceive = new DateTime(2023, 6, 22)},
            new Mark() {MarkId = 21, StudentId = 6, MarkValue = 3, SubjectId = 1, TimeReceive = new DateTime(2023, 6, 21)},
            new Mark() {MarkId = 22, StudentId = 6, MarkValue = 3, SubjectId = 2, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 23, StudentId = 6, MarkValue = 4, SubjectId = 3, TimeReceive = new DateTime(2023, 6, 17)},
            new Mark() {MarkId = 24, StudentId = 6, MarkValue = 2, SubjectId = 4, TimeReceive = new DateTime(2023, 6, 18)},
            new Mark() {MarkId = 25, StudentId = 7, MarkValue = 3, SubjectId = 1, TimeReceive = new DateTime(2023, 6, 18)},
            new Mark() {MarkId = 26, StudentId = 7, MarkValue = 4, SubjectId = 2, TimeReceive = new DateTime(2023, 6, 17)},
            new Mark() {MarkId = 27, StudentId = 7, MarkValue = 5, SubjectId = 3, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 28, StudentId = 7, MarkValue = 3, SubjectId = 4, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 29, StudentId = 8, MarkValue = 2, SubjectId = 1, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 30, StudentId = 8, MarkValue = 4, SubjectId = 2, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 31, StudentId = 8, MarkValue = 5, SubjectId = 3, TimeReceive = new DateTime(2023, 6, 20)},
            new Mark() {MarkId = 32, StudentId = 8, MarkValue = 5, SubjectId = 4, TimeReceive = new DateTime(2023, 6, 20)},
        };
    }

    public SeedDataGenerator()
    { 
        CreateListSubject();
        CreateListStudent();
        CreateListClassType();
        CreateListMark();
    }
}
