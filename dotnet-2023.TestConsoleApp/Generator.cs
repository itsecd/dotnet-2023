using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.InstitutionStructure;
using dotnet_2023.DataModel.Organization;
using dotnet_2023.DataModel.Person;

namespace dotnet_2023.TestConsoleApp;

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
        if (!File.Exists(Path + "Departments.txt"))
            throw new FileNotFoundException("FileNotFoundException");

        var lines = File.ReadAllLines(Path + "Departments.txt");

        return new Department()
        {
            Name = lines[department],
            Phone = Phone(),
            Email = Email(),
            IdFaculty = faculty.Id,
            Faculty = faculty,
            IdInstitute = institution.Id,
            Institute = institution,
        };
    }

    public static Faculty Faculty(int faculty,
        HigherEducationInstitution institution)
    {
        if (!File.Exists(Path + "Departments.txt"))
            throw new FileNotFoundException("FileNotFoundException");

        var lines = File.ReadAllLines(Path + "Faculity.txt");

        return new Faculty()
        {
            Name = lines[faculty],
            Phone = Phone(),
            Email = Email(),
            Institute = institution,
            IdInstitute = institution.Id,
        };
    }

    public static EducationWorker Rector(HigherEducationInstitution institution,
        string name)
    {
        var words = name.Split(' ');
        return new EducationWorker()
        {
            Name = words[1],
            Surname = words[0],
            Patronymic = words[2],
            Phone = Phone(),
            Email = Email(),
            ScienceDegree = "Научная степень",
            JobTitle = "Ректор",
            Rank = "Звание.",
            Salary = 100500,
            IdOrganization = institution.Id,
        };
    }


    public static HigherEducationInstitution Institution(int inst, int[] Fclts, 
        Dictionary<int, int[]> Dprtms)
    {
        if (!File.Exists(Path + "Departments.txt"))
            throw new FileNotFoundException("FileNotFoundException");

        var lines = File.ReadAllLines(Path + "Institute.txt");
        var elem = lines[inst].Split('\t');
        
        var institute = new HigherEducationInstitution()
        {
            Email = elem[5],
            Phone = elem[4],
            Initials = elem[0],
            FullName = elem[1],
            LegalAddress = elem[2],
            RegistrationNumber = RegisterNumber(),
            BuildingProperty = BuildingProperty.Federal,
            InstitutionalProperty = InstitutionalProperty.Municipal,
        };

        var rector = Rector(institute, elem[3]);
        institute.Rector = rector;
        institute.IdRector = rector.Id;

        for (var i = 0; i < Fclts.Length; i++)
        {
            var faculty = new Faculty();
            faculty = Faculty(Fclts[i], institute);
            for (var j = 0; j < Dprtms[Fclts[i]].Length; j++)
            {
                var tmpDeprt = Department(Dprtms[Fclts[i]][j], faculty, institute);
                institute.Departments!.Add(tmpDeprt);
                faculty.Departments!.Add(tmpDeprt);
            }
            institute.Faculties!.Add(faculty);
        }

        return institute;
    }


    public static Speciality Speciality(int spec)
    {
        if (!File.Exists(Path + "Departments.txt"))
            throw new FileNotFoundException("FileNotFoundException");

        var lines = File.ReadAllLines(Path + "Speciality.txt");
        var elem = lines[spec].Split('\t');

        var sp = new Speciality()
        {
            Code = elem[0],
            Title = elem[1],
            StudyFormat = StudyFormat.FullTime
        };

        return sp;
    }


    public static Student Student(Speciality speciality, GroupOfStudents group, 
        int id = -1, string name = "")
    {
        var student = new string[3];
        if (name == "")
        {
            if (!File.Exists(Path + "Names.txt"))
                throw new FileNotFoundException("FileNotFoundException");

            var lines = File.ReadAllLines(Path + "Names.txt");
            id = id >= lines.Length || id < 0 ? Rnd.Next(0, lines.Length) : id;
            student = lines[id].Split(' ');
        }
        else
            student = name.Split(' ');

        var res = new Student()
        {
            Name = student[1],
            Surname = student[0],
            Patronymic = student[2],
            Phone = Phone(),
            Email = Email(),
            Speciality = speciality,
            IdSpeciality = speciality.Code,
            IdGroup = group.Id,
            Group = group
        };
        group.Students!.Add(res);

        return res;
    }

    public static ICollection<Student> Students(int count, Speciality speciality,
        GroupOfStudents group)
    {
        if (!File.Exists(Path + "Names.txt"))
            throw new FileNotFoundException("FileNotFoundException");

        var lines = File.ReadAllLines(Path + "Names.txt");

        var collection = new List<Student>();
        for (var i = 0; i < count; i++)
            collection.Add(Student(speciality, group, -1, lines[Rnd.Next(0, lines.Length)]));

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

        for(var i = 0; i<count; i++)
            groupOfStudents.Add(GroupOfStudent(speciality, department));

        return groupOfStudents;
    }
}
