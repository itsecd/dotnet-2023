namespace UniversityData.Tests;
using System.Linq;

public class UnitTests : IClassFixture<UnitFixture>
{
    private UnitFixture _fixture;
    public UnitTests(UnitFixture unitFixture)
    {
        _fixture = unitFixture;
    }
    /// <summary>
    /// Запрос 1 - Вывести информацию о выбранном вузе.
    /// </summary>
    [Fact]
    public void InformationOfUniversity()
    {
        var result = (from university in _fixture.Universities
                      where university.Number == "12345"
                      select university).ToList();
        Assert.Equal("Самарский университет", result[0].Name);
    }
    /// <summary>
    /// Запрос 2 - Вывести информацию о факультетах, кафедрах и специальностях данного вуза.
    /// </summary>
    [Fact]
    public void InformationOfStructure()
    {
        var result = (from university in _fixture.Universities
                      where (university.Number == "45678")
                      select university).ToList();
        Assert.Equal(1, result[0].FacultiesData.Count);
        Assert.Equal(1, result[0].DepartmentsData.Count);
        Assert.Equal(4, result[0].SpecialtyTable.Count);
    }
    /// <summary>
    /// Запрос 3 - Вывести информацию о топ 5 популярных специальностях (с максимальным количеством групп).
    /// </summary>
    [Fact]
    public void TopFiveSpecialties()
    {
        var l = new List<string> { "10.05.03", "09.03.03", "09.03.02", "09.03.01", "01.03.02" };
        var result = (from specialtyNode in _fixture.SpecialtyTableNodes
                      group specialtyNode by specialtyNode.Specialty.Code into specialtyGroup
                      orderby specialtyGroup.Count() descending
                      select new
                      {
                          Specialty = specialtyGroup.Key,
                          numRequests = specialtyGroup.Count()
                      }).Take(5).ToList();
        for (var i = 0; i < 5; i++)
            Assert.Equal(l[i], result[i].Specialty);
    }
    /// <summary>
    /// Запрос 4 - Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию.
    /// </summary>
    [Fact]
    public void MaxCountDepartments()
    {
        var result = (from university in _fixture.Universities
                      where university.DepartmentsData.Count == _fixture.Universities.Max(x => x.DepartmentsData.Count)
                      select university).ToList();
        Assert.Equal(1, result.Count);
    }
    /// <summary>
    /// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе.
    /// </summary>
    [Fact]
    public void UniversityWithProperty()
    {
        var result = (from university in _fixture.Universities
                      where (university.UniversityProperty == "муниципальная")
                      where (university.SpecialtyTable.Sum(x => x.CountGroups) == 27)
                      select university).ToList();
        Assert.Equal(1, result.Count);
    }
    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания.
    /// </summary>
    [Fact]
    public void CountDepartments()
    {
        var result = (from university in _fixture.Universities
                      group university by university.ConstructionProperty into universityConstGroup
                      from universityPropGroup in
                      (
                          from university in universityConstGroup
                          group university by university.UniversityProperty into universityPropGroup
                          select new
                          {
                              UnivesityProp = universityPropGroup.Key
                          }
                      )
                      select new
                      {
                          ConstProp = universityConstGroup.Key,
                          UniversityProp = universityPropGroup.UnivesityProp,
                          Faculties = universityConstGroup.Sum(x => x.FacultiesData.Count),
                          Departments = universityConstGroup.Sum(x => x.DepartmentsData.Count),
                          Specialities = universityConstGroup.Sum(x => x.SpecialtyTable.Count)
                      }
                      ).ToList();
        Assert.Equal("муниципальная", result[0].UniversityProp);
        Assert.Equal("муниципальная", result[1].UniversityProp);
        Assert.Equal("муниципальная", result[0].ConstProp);
        Assert.Equal("федеральная", result[1].ConstProp);
        Assert.Equal(5, result[0].Faculties);
        Assert.Equal(1, result[1].Faculties);
        Assert.Equal(3, result[0].Departments);
        Assert.Equal(1, result[1].Departments);
        Assert.Equal(7, result[0].Specialities);
        Assert.Equal(4, result[1].Specialities);
    }
}