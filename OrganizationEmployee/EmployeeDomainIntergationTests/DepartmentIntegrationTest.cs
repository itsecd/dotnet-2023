using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationServer.Dto;
using System.Text;

public class DepartmentIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public DepartmentIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetDepartments()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Department");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var departments = JsonConvert.DeserializeObject<List<DepartmentDto>>(content);
        Assert.NotNull(departments);
        Assert.True(departments.Count >= 8);
    }

    [Theory]
    [InlineData(10, "Отдел снабжения и закупок", true)]
    [InlineData(2, "Отдел программирования", true)]
    [InlineData(9, "Отдел логистики", true)]
    [InlineData(1337, "", false)]
    [InlineData(555, "", false)]
    public async Task GetDepartment(uint departmentId, string departmentName, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/Department/{0}", departmentId));

        var content = await response.Content.ReadAsStringAsync();
        var department = JsonConvert.DeserializeObject<DepartmentDto>(content);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(department);
            Assert.Equal(departmentName, department.Name);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }

    [Theory]
    [InlineData("Отдел техобслуживания")]
    [InlineData("Отдел медицинской помощи")]
    public async Task PostDepartment(string departmentName)
    {
        var departmentDto = new DepartmentDto()
        {
            Name = departmentName
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(departmentDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/Department", stringContent);
        Assert.True(response.IsSuccessStatusCode);
    }
    /*
    [Theory]
    [InlineData(2, 1456, "Иван", "Иванов", "Иванович", 2000, 10, 28, 1, "г.Самара Московское шоссе, д.12",
        "89633154365", "88005553535", "холост", 2, 0, true)]
    [InlineData(2, 1456, "Иван", "Иванов", "Иванович", 2000, 10, 28, 0, "г.Самара Московское шоссе, д.12",
        "89633154365", "88005553535", "холост", 2, 0, false)]
    [InlineData(5653, 1456, "Иван", "Иванов", "Иванович", 2000, 10, 28, 1, "г.Самара Московское шоссе, д.12",
        "89633154365", "88005553535", "холост", 2, 0, false)]
    public async Task PutEmployee(uint employeeId, uint regNumber, string firstName, string lastName, string patronymicName,
        int birthYear, int birthMonth, int birthDay, int workshopId, string homeAddress, string homeTelephone,
        string workTelephone, string familyStatus, uint familyMembersCount, uint childrenCount, bool isSuccess)
    {
        var employeeDto = new EmployeeDto()
        {
            RegNumber = regNumber,
            FirstName = firstName,
            LastName = lastName,
            PatronymicName = patronymicName,
            BirthDate = new DateTime(birthYear, birthMonth, birthDay),
            WorkshopId = workshopId,
            HomeAddress = homeAddress,
            HomeTelephone = homeTelephone,
            WorkTelephone = workTelephone,
            FamilyStatus = familyStatus,
            FamilyMembersCount = familyMembersCount,
            ChildrenCount = childrenCount
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(employeeDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PutAsync(string.Format("api/Employee/{0}", employeeId), stringContent);

        var content = await response.Content.ReadAsStringAsync();
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }


    [Theory]
    [InlineData(1, true)]
    [InlineData(133, false)]
    public async Task DeleteEmployee(int employeeId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync(string.Format("api/Employee/{0}", employeeId));
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }*/
}