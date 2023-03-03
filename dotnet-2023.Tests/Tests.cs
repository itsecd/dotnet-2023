using dotnet_2023.Tests.DataBase;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using dotnet_2023.DataModel.Organization;
using dotnet_2023.DataModel.InstitutionStructure;

namespace dotnet_2023.Tests;
public class Tests
{
    public Tests()
    {
        DataBasaContext = new DBContext();
        var inst = DataBasaContext.Institutes.ToList();
        var instspec = DataBasaContext.InstituteSpecialties.ToList();
        var spec = DataBasaContext.Specialties.ToList();
        var faculty = DataBasaContext.Faculties.ToList();
        var deprnt = DataBasaContext.Departments.ToList();
        var group = DataBasaContext.GroupOfStudents.ToList();
        var edworker = DataBasaContext.EducationWorker.ToList();
        var students = DataBasaContext.Students.ToList();
    }
    public DBContext DataBasaContext { get; set; }


    [Fact]
    public void UniversityFirst()
    {
        var ssau = DataBasaContext.Institutes
            .FirstOrDefault(x => x.Initials == "СНИУ");

        Assert.NotNull(ssau);
        Assert.Equal("СНИУ", ssau!.Initials);
    }


    [Fact]
    public void TestPopularSpecialties()
    {
        var expected = new string[]
        {
            "2.09.05.01", "2.09.02.04", "1.01.05.01", "1.01.03.04", "1.02.03.02"
        };

        var actual = DataBasaContext.Specialties
            .Select(x => x)
            .OrderByDescending(x => DataBasaContext.GroupOfStudents
                .Count(i => i.IdSpeciality == x.Code))
            .Take(5)
            .ToArray();

        for (var i = 0; i < expected.Length; i++)
            Assert.Equal(expected[i], actual[i].Code);
  
    }

    [Fact]
    public void MaxDepartment()
    {
        var expected = new string[] {
            "d0e4ca0b-baf2-4de2-b809-65d3fe0e8f68",
            "e7fe6d4e-ccda-4d87-b566-1466ce582f96",
            "d5cb88e6-7379-4e22-b295-ea95ff0e7ec1",
            "146d6fa8-2cf7-420f-aed4-cac81684b269",
            "09559115-9562-4f0a-8311-67836bfe1dd6" };

        var actual = DataBasaContext.Institutes
            .Select(x => x)
            .OrderByDescending(x => x.Departments.Count)
            .ThenBy(x=>x.FullName)
            .ToArray();

        for (var i = 0; i < expected.Length; i++)
            Assert.Equal(expected[i], actual[i].Id);
    }

    [Fact]
    public void OwnershipInstitutionAndGroup()
    {
        var type = InstitutionalProperty.Private;

        var groups = DataBasaContext.Institutes
            .Where(x => x.InstitutionalProperty == type)
            .ToDictionary(x => x,
            e => e.Departments.Sum(i => i.GroupOfStudents.Count()));
        var o = 0;
    }

}
