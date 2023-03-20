using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.Domain.Organization;
using DotNet2023.Domain.Person;
using System.Text.Json;

namespace DotNet2023.TestConsoleApp;

public static class Generator
{
    public static string Path = "..\\..\\..\\DataFiles\\";
    public static Random Rnd { get; } = new Random();

    public static string Email()
    {
        var domains = new string[] { "@mail.ru", "@gmail.com", "@yandex.ru", "@yandex.com" };
        var email = "";
        var rnd = new Random();

        for (var i = 0; i < rnd.Next(5, 15); i++)
            email += (char)rnd.Next(97, 122);

        return email + domains[rnd.Next(0, domains.Length - 1)];
    }
    public static string? Phone()
    {
        var phone = "";
        for (var i = 0; i < 9; i++)
            phone += (char)Rnd.Next(48, 57);

        return "7" + phone;
    }
    public static string? RegisterNumber()
    {
        var phone = "";
        for (var i = 0; i < 13; i++)
            phone += (char)Rnd.Next(48, 57);

        return phone;
    }

    public static Department Department(int department, Faculty faculty,
    HigherEducationInstitution institution)
    {
        if (!File.Exists(Path + "Departments.json"))
            throw new FileNotFoundException("FileNotFoundException");

        var departments = new List<Department>();

        using (var fs = new FileStream("..\\..\\..\\DataFiles\\Departments.json", FileMode.Open))
        {
            departments = JsonSerializer.Deserialize<List<Department>>(fs);
        }

        if (department > departments.Count)
            throw new ArgumentOutOfRangeException($"Argument out of Range. " +
                $"Yout index - {department}, count elements in collection - {departments.Count}");

        departments[department].Institute = institution;
        departments[department].IdInstitute = institution.Id;
        departments[department].IdFaculty = faculty.Id;
        departments[department].Faculty = faculty;

        return departments[department];
    }

    public static Faculty Faculty(int faculty,
        HigherEducationInstitution institution)
    {
        if (!File.Exists(Path + "Faculty.json"))
            throw new FileNotFoundException("FileNotFoundException");

        var faculties = new List<Faculty>();

        using (var fs = new FileStream("..\\..\\..\\DataFiles\\Faculty.json", FileMode.Open))
        {
            faculties = JsonSerializer.Deserialize<List<Faculty>>(fs);
        }

        if (faculty > faculties.Count)
            throw new ArgumentOutOfRangeException($"Argument out of Range. " +
                $"Yout index - {faculty}, count elements in collection - {faculties.Count}");

        faculties[faculty].IdInstitute = institution.Id;
        faculties[faculty].Institute = institution;
        return faculties[faculty];
    }


    public static HigherEducationInstitution Institution(int inst, int[] faculties,
        Dictionary<int, int[]> departments)
    {
        if (!File.Exists(Path + "Institute.json"))
            throw new FileNotFoundException("FileNotFoundException");

        var institutions = new List<HigherEducationInstitution>();

        using (var fs = new FileStream(Path + "Institute.json", FileMode.Open))
        {
            institutions = JsonSerializer.Deserialize<List<HigherEducationInstitution>>(fs);
        }

        if (inst > institutions.Count)
            throw new ArgumentOutOfRangeException($"Argument out of Range. " +
                $"Yout index - {inst}, count elements in collection - {institutions.Count}");


        var institute = institutions[inst];

        for (var i = 0; i < faculties.Length; i++)
        {
            var faculty = Faculty(faculties[i], institute);
            for (var j = 0; j < departments[faculties[i]].Length; j++)
            {
                var tmpDepartment = Department(departments[faculties[i]][j], faculty, institute);
                institute.Departments!.Add(tmpDepartment);
                faculty.Departments!.Add(tmpDepartment);
            }
            institute.Faculties!.Add(faculty);
        }

        return institute;
    }


    public static Speciality Speciality(int speciality)
    {
        if (!File.Exists(Path + "Speciality.json"))
            throw new FileNotFoundException("FileNotFoundException");

        var specialties = new List<Speciality>();

        using (var fs = new FileStream(Path+"Speciality.json", FileMode.OpenOrCreate))
        {
            specialties = JsonSerializer.Deserialize<List<Speciality>>(fs);
        }
        if (speciality > specialties!.Count)
            throw new ArgumentOutOfRangeException($"Argument out of Ragne. " +
                $"Your id: {speciality}, count elements: {specialties.Count}");

        return specialties[speciality];
    }


    public static Student Student(Speciality speciality, GroupOfStudents group, 
        BasePerson person)
    {
        var student = new Student()
        {
            Name = person.Name,
            Surname = person.Surname,
            Patronymic = person.Patronymic,
            Phone = person.Phone,
            Email = person.Email,
            Speciality = speciality,
            IdSpeciality = speciality.Code,
            IdGroup = group.Id,
            Group = group
        };
        group.Students!.Add(student);

        return student;
    }

    public static ICollection<Student> Students(int count, Speciality speciality,
        GroupOfStudents group)
    {
        if (!File.Exists(Path + "Persons.json"))
            throw new FileNotFoundException("FileNotFoundException");

        var persons = new List<Student>();
        using (var fs = new FileStream(Path + "Persons.json", FileMode.Open))
        {
            persons.AddRange(JsonSerializer.Deserialize<List<Student>>(fs));
        }

        var collection = new List<Student>();
        for (var i = 0; i < count; i++)
            collection.Add(Student(speciality, group, persons[Rnd.Next(0, persons.Count)]));     

        return collection;
    }

    public static GroupOfStudents GroupOfStudent(Speciality speciality,
    Department department)
    {
        var res = new GroupOfStudents()
        {
            IdDepartment = department.Id,
            Department = department,
            Speciality = speciality,
            IdSpeciality = speciality.Code,
            Phone = Phone(),
            Email = Email(),
            Name = speciality.Code + "-D",
        };

        res.Students = Students(Rnd.Next(10, 35), speciality, res);
        department.GroupOfStudents!.Add(res);

        return res;

    }

    public static ICollection<GroupOfStudents> GroupOfStudents(int count,
        Speciality speciality, Department department)
    {
        var groupOfStudents = new List<GroupOfStudents>();

        for (var i = 0; i < count; i++)
            groupOfStudents.Add(GroupOfStudent(speciality, department));

        return groupOfStudents;
    }
}