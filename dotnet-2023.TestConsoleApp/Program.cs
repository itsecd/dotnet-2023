using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.InstitutionStructure;
using dotnet_2023.DataModel.Organization;
using dotnet_2023.DataModel.Person;
using dotnet_2023.lib.FillDataBase.Generation;
using dotnet_2023.TestConsoleApp.DBContext;

Console.WriteLine("First Meow");

using (var db = new DbContextTest())
{
    var ssau = new GenerationRandomInsitute().GenerationDefinite(4) as HigherEducationInstitution;

    var rectorSSAU = new EducationWorker()
    {
        Name = "Владимир",
        Surname = "Богатырев",
        Patronymic = "Димович",
        Salary = 100500,
        JobTitle = "Ректор",
        ScienceDegree = "Присутствует",
        Phone = "12345678901",
        Email = "bogVladDima.ssau@ssau.ru",
        Rank = "Звание умное",
        Organization = ssau,
        IdOrganization = ssau.Id,
        BirthDay = DateTime.Now,
    };

    ssau.Rector = rectorSSAU;
    ssau.IdRector = rectorSSAU.Id;

    var facultyOne = new GenerationRandomFaculty().GenerationDefinite(0) as Faculty;
    var facultyTwo = new GenerationRandomFaculty().GenerationDefinite(1) as Faculty;
    var facultyFour = new GenerationRandomFaculty().GenerationDefinite(5) as Faculty;
    var facultyThree = new GenerationRandomFaculty().GenerationDefinite(6) as Faculty;

    facultyOne.IdInstitute = ssau.Id;
    facultyTwo.IdInstitute = ssau.Id;
    facultyThree.IdInstitute = ssau.Id;
    facultyFour.IdInstitute = ssau.Id;

    facultyFour.Institute = ssau;
    facultyOne.Institute = ssau;
    facultyThree.Institute = ssau;
    facultyTwo.Institute = ssau;


    var departmentOne = new GenerationRandomDepartment().GenerationDefinite(0) as Department;

    var departmentTwo = new GenerationRandomDepartment().GenerationDefinite(1) as Department;
    var departmentThree = new GenerationRandomDepartment().GenerationDefinite(4) as Department;

    var departmentFour = new GenerationRandomDepartment().GenerationDefinite(9) as Department;
    var departmentFive = new GenerationRandomDepartment().GenerationDefinite(11) as Department;

    var departmentSix = new GenerationRandomDepartment().GenerationDefinite(13) as Department;
    var departmentSeven = new GenerationRandomDepartment().GenerationDefinite(7) as Department;
    var departmentEinght = new GenerationRandomDepartment().GenerationDefinite(2) as Department;

    departmentOne.Faculty = facultyOne;
    departmentOne.IdFaculty = facultyOne.Id;
    departmentOne.Institute = ssau;
    departmentOne.IdInstitute = ssau.Id;

    departmentTwo.Faculty = facultyTwo;
    departmentTwo.IdFaculty = facultyTwo.Id;
    departmentThree.Faculty = facultyTwo;
    departmentThree.IdFaculty = facultyTwo.Id;
    departmentTwo.Institute = ssau;
    departmentTwo.IdInstitute = ssau.Id;
    departmentThree.Institute = ssau;
    departmentThree.IdInstitute = ssau.Id;

    departmentFour.Faculty = facultyThree;
    departmentFour.IdFaculty = facultyThree.Id;
    departmentFive.Faculty = facultyThree;
    departmentFive.IdFaculty = facultyThree.Id;
    departmentFour.Institute = ssau;
    departmentFour.IdInstitute = ssau.Id;
    departmentFive.Institute = ssau;
    departmentFive.IdInstitute = ssau.Id;

    departmentSix.Faculty = facultyFour;
    departmentSix.IdFaculty = facultyFour.Id;
    departmentSeven.Faculty = facultyFour;
    departmentSeven.IdFaculty = facultyFour.Id;
    departmentEinght.Faculty = facultyFour;
    departmentEinght.IdFaculty = facultyFour.Id;
    departmentSix.Institute = ssau;
    departmentSix.IdInstitute = ssau.Id;
    departmentSeven.Institute = ssau;
    departmentSeven.IdInstitute = ssau.Id;
    departmentEinght.Institute = ssau;
    departmentEinght.IdInstitute = ssau.Id;


    var groupGIIS = new List<GroupOfStudents>();

    for(var i = 0; i < 4; i++)
    {
        var tmp = new GenerationRandomGroup().Generation() as GroupOfStudents;
        groupGIIS.Add(tmp);
    }
    
    var specGIIT = new GenerationRandomSpeciality().GenerationDefinite(14) as Speciality;
    
    foreach(var elem in groupGIIS)
    {
        elem.IdDepartment = departmentOne.Id;
        elem.Department = departmentOne;
        elem.IdSpeciality = specGIIT.Code;
        elem.Speciality = specGIIT;
    }

    Console.WriteLine("Second Meow");
}