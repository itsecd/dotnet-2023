using DotNet2023.Domain.Organization;
using DotNet2023.Tests.DataBase;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotNet2023.Tests;
public class FirstLabTests
{
    public FirstLabTests()
    {
        DataBasaContext = new DBContext();
        DataBasaContext.Institutes.ToList();
        DataBasaContext.InstituteSpecialties.ToList();
        DataBasaContext.Specialties.ToList();
        DataBasaContext.Faculties.ToList();
        DataBasaContext.Departments.ToList();
        DataBasaContext.GroupOfStudents.ToList();
        DataBasaContext.EducationWorker.ToList();
        DataBasaContext.Students.ToList();
    }
    public DBContext DataBasaContext { get; set; }

    [Theory]
    [InlineData("СНИУ", "СНИУ", "d5cb88e6-7379-4e22-b295-ea95ff0e7ec1")]
    [InlineData("СГЭУ", "СГЭУ", "09559115-9562-4f0a-8311-67836bfe1dd6")]
    [InlineData("КНИТУ", "КНИТУ", "146d6fa8-2cf7-420f-aed4-cac81684b269")]
    [InlineData("КФУ", "КФУ", "d0e4ca0b-baf2-4de2-b809-65d3fe0e8f68")]
    [InlineData("СГТУ", "СГТУ", "e7fe6d4e-ccda-4d87-b566-1466ce582f96")]

    public void InformationUniversity(string initials, string expectedInitials,
        string expectedId)
    {
        var actual = DataBasaContext.Institutes
            .FirstOrDefault(x => x.Initials == initials);
        Assert.NotNull(actual);
        Assert.Equal(expectedInitials, actual!.Initials);
        Assert.Equal(expectedId, actual.Id);
    }

    [Theory]
    [InlineData("СНИУ", 3, 9, 13)]
    [InlineData("КФУ", 3, 10, 20)]
    [InlineData("СГЭУ", 2, 4, 6)]
    [InlineData("СГТУ", 4, 9, 12)]
    [InlineData("КНИТУ", 3, 6, 10)]
    public void InfrormationStructUniversity(string initials, int expectedCountFaculties,
        int expectedCountDepartments, int expectedCountSpecialties)
    {
        var actual = DataBasaContext.Institutes
            .Where(x => x.Initials == initials)
            .Select(x => new
            {
                name = x.Initials,
                faculties = x.Faculties.Count(),
                departments = x.Departments.Count(),
                specialties = x!.Specialties
                    .Select(i => i.Speciality).Count()
            }).ToArray();

        Assert.NotNull(actual);
        Assert.Equal(expectedCountFaculties, actual.First().faculties);
        Assert.Equal(expectedCountDepartments, actual.First().departments);
        Assert.Equal(expectedCountSpecialties, actual.First().specialties);
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
            .ThenBy(x => x.FullName)
            .ToArray();

        for (var i = 0; i < expected.Length; i++)
            Assert.Equal(expected[i], actual[i].Id);
    }


    [Theory]
    [MemberData("GetDataOwnershipInstitutionAndGroup")]
    public void OwnershipInstitutionAndGroup(InstitutionalProperty property,
        Dictionary<string, int> expected)
    {
        var actual = DataBasaContext.Institutes
            .Where(x => x.InstitutionalProperty == property)
            .ToDictionary(x => x.Id,
            e => e.Departments
            .Sum(i => i.GroupOfStudents.Count()));

        Assert.Equal(expected.Count, actual.Count);

        foreach (var elem in actual)
        {
            Assert.True(actual.Contains(elem));
        }
    }

    public static IEnumerable<object[]> GetDataOwnershipInstitutionAndGroup()
    {
        var expectedMunicipal = new Dictionary<string, int>();
        expectedMunicipal.Add("09559115-9562-4f0a-8311-67836bfe1dd6", 15);
        expectedMunicipal.Add("d0e4ca0b-baf2-4de2-b809-65d3fe0e8f68", 38);
        expectedMunicipal.Add("d5cb88e6-7379-4e22-b295-ea95ff0e7ec1", 21);

        var expectedPrivate = new Dictionary<string, int>();
        expectedPrivate.Add("146d6fa8-2cf7-420f-aed4-cac81684b269", 22);
        expectedPrivate.Add("e7fe6d4e-ccda-4d87-b566-1466ce582f96", 23);

        yield return new object[] { InstitutionalProperty.Municipal, expectedMunicipal };
        yield return new object[] { InstitutionalProperty.Private, expectedPrivate };
    }


    public struct ResponseBuildingAndOwnership
    {
        public string Name;
        public int countFaculties;
        public int countDepartments;
        public int countGroups;
    };

    [Fact]
    public void BuildingAndOwnership()
    {
        var expected = new ResponseBuildingAndOwnership[]
        {
            new ResponseBuildingAndOwnership()
            {
                Name = "КФУ",
                countFaculties = 3,
                countDepartments = 10,
                countGroups = 38,
            },
            new ResponseBuildingAndOwnership()
            {
                Name = "СНИУ",
                countFaculties = 3,
                countDepartments = 9,
                countGroups = 21,
            },
            new ResponseBuildingAndOwnership()
            {
                Name = "СГЭУ",
                countFaculties = 2,
                countDepartments = 4,
                countGroups = 15,
            },
            new ResponseBuildingAndOwnership()
            {
                Name = "СГТУ",
                countFaculties = 4,
                countDepartments = 9,
                countGroups = 23,
            },
            new ResponseBuildingAndOwnership()
            {
                Name = "КНИТУ",
                countFaculties = 3,
                countDepartments = 6,
                countGroups = 22,
            }
        };

        var actual = DataBasaContext.Institutes
            .OrderBy(x => x.InstitutionalProperty)
            .ThenBy(x => x.BuildingProperty)
            .Select(x => new
            {
                name = x.Initials,
                faculties = x.Faculties.Count,
                departments = x.Departments.Count,
                groups = x.Departments
                    .SelectMany(i => i.GroupOfStudents)
                    .Count()
            })
            .ToArray();

        Assert.Equal(expected.Length, actual.Length);

        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i].Name, actual[i].name);
            Assert.Equal(expected[i].countFaculties, actual[i].faculties);
            Assert.Equal(expected[i].countDepartments, actual[i].departments);
            Assert.Equal(expected[i].countGroups, actual[i].groups);
        }
    }


    [Theory]
    [MemberData("GetDataBuildingAndOwnershipByType")]
    public void BuildingAndOwnershipByType(InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty,
        ResponseBuildingAndOwnership[] expected)
    {
        var actual = DataBasaContext.Institutes
            .Where(x =>
                x.InstitutionalProperty == institutionalProperty &&
                x.BuildingProperty == buildingProperty)
            .Select(x => new
            {
                name = x.Initials,
                faculties = x.Faculties.Count,
                departments = x.Departments.Count,
                groups = x.Departments.SelectMany(i => i.GroupOfStudents)
                    .Count()
            })
            .ToArray();

        Assert.Equal(expected.Length, actual.Length);
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i].Name, actual[i].name);
            Assert.Equal(expected[i].countFaculties, actual[i].faculties);
            Assert.Equal(expected[i].countDepartments, actual[i].departments);
            Assert.Equal(expected[i].countGroups, actual[i].groups);
        }
    }


    public static IEnumerable<object[]> GetDataBuildingAndOwnershipByType()
    {
        var expectedMunicipalMunicipal = new ResponseBuildingAndOwnership[]
        {
            new ResponseBuildingAndOwnership()
            {
                Name = "КФУ",
                countFaculties = 3,
                countDepartments = 10,
                countGroups = 38,
            },
        };
        var expectedMunicipalPrivate = new ResponseBuildingAndOwnership[] { };
        var expectedMunicipalFederal = new ResponseBuildingAndOwnership[] {
            new ResponseBuildingAndOwnership()
            {
                Name = "СГЭУ",
                countFaculties = 2,
                countDepartments = 4,
                countGroups = 15,
            },
            new ResponseBuildingAndOwnership()
            {
                Name = "СНИУ",
                countFaculties = 3,
                countDepartments = 9,
                countGroups = 21,
            }
        };

        var expectedPrivateMunicipal = new ResponseBuildingAndOwnership[]
        {
            new ResponseBuildingAndOwnership()
            {
                Name = "СГТУ",
                countFaculties = 4,
                countDepartments = 9,
                countGroups = 23,
            }
        };
        var expectedPrivatePrivate = new ResponseBuildingAndOwnership[]
        {
            new ResponseBuildingAndOwnership()
            {
                Name = "КНИТУ",
                countFaculties = 3,
                countDepartments = 6,
                countGroups = 22,
            },
        };
        var expectedPrivateFederal = new ResponseBuildingAndOwnership[] { };

        yield return new object[] { InstitutionalProperty.Municipal,
            BuildingProperty.Municipal, expectedMunicipalMunicipal };
        yield return new object[] { InstitutionalProperty.Municipal,
            BuildingProperty.Private, expectedMunicipalPrivate };
        yield return new object[] { InstitutionalProperty.Municipal,
            BuildingProperty.Federal, expectedMunicipalFederal };
        yield return new object[] { InstitutionalProperty.Private,
            BuildingProperty.Municipal, expectedPrivateMunicipal };
        yield return new object[] { InstitutionalProperty.Private,
            BuildingProperty.Private, expectedPrivatePrivate };
        yield return new object[] { InstitutionalProperty.Private,
            BuildingProperty.Federal, expectedPrivateFederal };
    }
}
