using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrganizationEmployee.Server.Dto;
using System.Text;

namespace OrganizationEmployee.IntegrationTests;
public class EmployeeOccupationIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public EmployeeOccupationIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetEmployeeOccupations()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("api/EmployeeOccupation");
        Assert.True(response.IsSuccessStatusCode);

        var content = await response.Content.ReadAsStringAsync();
        var employeeOccupations = JsonConvert.DeserializeObject<List<EmployeeOccupationDto>>(content);
        Assert.NotNull(employeeOccupations);
        Assert.True(employeeOccupations.Count >= 1);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(1337, false)]
    [InlineData(555, false)]
    public async Task GetEmployeeOccupation(uint employeeOccupationId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client
            .GetAsync(string.Format("api/EmployeeOccupation/{0}", employeeOccupationId));

        var content = await response.Content.ReadAsStringAsync();
        var employeeOccupation = JsonConvert.DeserializeObject<EmployeeOccupationDto>(content);
        if (isSuccess)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(employeeOccupation);
        }
        else
        {
            Assert.False(response.IsSuccessStatusCode);
        }
    }

    [Theory]
    [InlineData(1, 1, 2000, 1, 3, 2020, 3, 24, true)]
    [InlineData(1, 2011, 2000, 1, 3, 2020, 3, 24, false)]
    [InlineData(2011, 1, 2000, 1, 3, 2020, 3, 24, false)]
    public async Task PostEmployeeOccupation(uint occupationId, uint employeeId, int hireYear, int hireMonth, int hireDay,
        int dismissalYear, int dismissalMonth, int dismissalDay, bool isSuccess)
    {
        var employeeOccupationDto = new EmployeeOccupationDto()
        {
            HireDate = new DateTime(hireYear, hireMonth, hireDay),
            DismissalDate = new DateTime(dismissalYear, dismissalMonth, dismissalDay),
            OccupationId = occupationId,
            EmployeeId = employeeId,
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(employeeOccupationDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client.PostAsync("api/EmployeeOccupation", stringContent);
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
    [InlineData(2, 1, 1, 2000, 1, 3, 2020, 3, 24, true)]
    [InlineData(55, 1, 1, 2000, 1, 3, 2020, 3, 24, false)]
    [InlineData(2, 1333, 1, 2000, 1, 3, 2020, 3, 24, false)]
    [InlineData(2, 1, 1333, 2000, 1, 3, 2020, 3, 24, false)]
    public async Task PutEmployeeOccupation(uint employeeOccupationId, uint occupationId, uint employeeId,
        int hireYear, int hireMonth, int hireDay, int dismissalYear,
        int dismissalMonth, int dismissalDay, bool isSuccess)
    {
        var employeeOccupationDto = new EmployeeOccupationDto()
        {
            HireDate = new DateTime(hireYear, hireMonth, hireDay),
            DismissalDate = new DateTime(dismissalYear, dismissalMonth, dismissalDay),
            OccupationId = occupationId,
            EmployeeId = employeeId,
        };
        var client = _factory.CreateClient();
        var jsonObject = JsonConvert.SerializeObject(employeeOccupationDto);
        var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
        var response = await client
            .PutAsync(string.Format("api/EmployeeOccupation/{0}", employeeOccupationId), stringContent);

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
    [InlineData(3, true)]
    [InlineData(133, false)]
    public async Task DeleteEmployeeOccupationId(uint employeeOccupationId, bool isSuccess)
    {
        var client = _factory.CreateClient();

        var response = await client
            .DeleteAsync(string.Format("api/EmployeeOccupation/{0}", employeeOccupationId));
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