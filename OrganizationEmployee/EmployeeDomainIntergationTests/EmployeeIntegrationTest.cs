using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationServer.Dto;
using System.Text;
namespace EmployeeDomain.IntegrationTests;

public class EmployeeIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public EmployeeIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetEmployees()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/Employee");

        var content = await response.Content.ReadAsStringAsync();
        var employees = JsonConvert.DeserializeObject<List<EmployeeDto>>(content);
        Assert.NotNull(employees);
        Assert.True(employees.Count >= 3);
    }

    [Theory]
    [InlineData(0, 1337, true)]
    [InlineData(2, 3, true)]
    [InlineData(3, 5, true)]
    [InlineData(1337, 0, false)]
    [InlineData(555, 0, false)]
    public async Task GetEmployee(uint employeeId, uint employeeRegNumber, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(string.Format("api/Employee/{0}", employeeId));

        var content = await response.Content.ReadAsStringAsync();
        var employee = JsonConvert.DeserializeObject<EmployeeDto>(content);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(employee);
            Assert.Equal(employeeRegNumber, employee.RegNumber);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }

    [Theory]
    [InlineData(1456, "Иван", "Иванов", "Иванович", 2000, 10, 28, 1, "г.Самара Московское шоссе, д.12",
        "89633154365", "88005553535", "холост", 2, 0, true)]
    [InlineData(1456, "Иван", "Иванов", "Иванович", 2000, 10, 28, 0, "г.Самара Московское шоссе, д.12",
    "89633154365", "88005553535", "холост", 2, 0, false)]
    [InlineData(1337, "Иван", "Иванов", "Иванович", 2000, 10, 28, 1, "г.Самара Московское шоссе, д.12",
    "89633154365", "88005553535", "холост", 2, 0, false)]
    public async Task PostEmployee(uint regNumber, string firstName, string lastName, string patronymicName,
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
        var response = await client.PostAsync("api/Employee", stringContent);

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
    }
}