using DotNet2023.Domain.Organization;
using DotNet2023.Queries;
using DotNet2023.Tests.DataBase;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotNet2023.Tests.UnitTests.Queries;
public class QueriesTest
{
    public QueriesTest()
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

    public void InformationUniversity(string initials,
        string expectedInitials, string expectedId)
    {
        var actual = QueriesToDomainModel
            .GetInstitutionByInitials(DataBasaContext, initials);

        Assert.NotNull(actual);
        Assert.NotNull(actual!.Initials);
        Assert.Equal(expectedInitials, actual.Initials);
        Assert.Equal(expectedId, actual.Id);
    }

    [Theory]
    [InlineData("СНИУ", 3, 9, 13)]
    [InlineData("КФУ", 3, 10, 20)]
    [InlineData("СГЭУ", 2, 4, 6)]
    [InlineData("СГТУ", 4, 9, 12)]
    [InlineData("КНИТУ", 3, 6, 10)]
    public void InfrormationStructUniversity(string initials,
        int expectedCountFaculties, int expectedCountDepartments,
        int expectedCountSpecialties)
    {
        var actual = QueriesToDomainModel
            .GetInstitutionStructByInitials(DataBasaContext, initials);

        Assert.NotNull(actual);
        Assert.Equal(expectedCountFaculties, actual!.CountFaculties);
        Assert.Equal(expectedCountDepartments, actual.CountDepartments);
        Assert.Equal(expectedCountSpecialties, actual.CountSpecialities);
    }


    [Fact]
    public void TestPopularSpecialties()
    {
        var expected = new string[]
        {
            "2.09.05.01", "2.09.02.04", "1.01.05.01", "1.01.03.04", "1.02.03.02"
        };

        var actual = QueriesToDomainModel
            .GetPopularSpeciality(DataBasaContext);

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

        var actual = QueriesToDomainModel
            .GetInstitutionsWithMaxDepartments(DataBasaContext);

        for (var i = 0; i < expected.Length; i++)
            Assert.Equal(expected[i], actual[i].Id);
    }


    [Theory]
    [MemberData("GetDataOwnershipInstitutionAndGroup")]
    public void OwnershipInstitutionAndGroup(InstitutionalProperty property,
        Dictionary<string, int> expected)
    {
        var actual = QueriesToDomainModel
            .GetOwnershipInstitutionAndGroup(DataBasaContext, property);

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

    [Theory]
    [MemberData("GetDataBuildingAndOwnershipByType")]
    public void BuildingAndOwnershipByType(InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty,
        ResponseUniversityStructByProperty[]? expected)
    {
        var actual = QueriesToDomainModel.GetInstitutionStruct(
            DataBasaContext, institutionalProperty,
            buildingProperty);

        Assert.Equal(expected.Length, actual.Length);
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i].Name, actual[i].Name);
            Assert.Equal(expected[i].CountFaculties, actual[i].CountFaculties);
            Assert.Equal(expected[i].CountDepartments, actual[i].CountDepartments);
            Assert.Equal(expected[i].CountGroups, actual[i].CountGroups);
        }
    }

    public static IEnumerable<object[]> GetDataBuildingAndOwnershipByType()
    {
        var expectedMunicipalMunicipal = new ResponseUniversityStructByProperty[]
        {
            new ResponseUniversityStructByProperty()
            {
                Name = "КФУ",
                CountFaculties = 3,
                CountDepartments = 10,
                CountGroups = 38,
            },
        };
        var expectedMunicipalPrivate = new ResponseUniversityStructByProperty[] { };
        var expectedMunicipalFederal = new ResponseUniversityStructByProperty[] {
            new ResponseUniversityStructByProperty()
            {
                Name = "СГЭУ",
                CountFaculties = 2,
                CountDepartments = 4,
                CountGroups = 15,
            },
            new ResponseUniversityStructByProperty()
            {
                Name = "СНИУ",
                CountFaculties = 3,
                CountDepartments = 9,
                CountGroups = 21,
            }
        };

        var expectedPrivateMunicipal = new ResponseUniversityStructByProperty[]
        {
            new ResponseUniversityStructByProperty()
            {
                Name = "СГТУ",
                CountFaculties = 4,
                CountDepartments = 9,
                CountGroups = 23,
            }
        };
        var expectedPrivatePrivate = new ResponseUniversityStructByProperty[]
        {
            new ResponseUniversityStructByProperty()
            {
                Name = "КНИТУ",
                CountFaculties = 3,
                CountDepartments = 6,
                CountGroups = 22,
            },
        };
        var expectedPrivateFederal = new ResponseUniversityStructByProperty[] { };

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
