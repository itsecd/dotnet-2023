using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet2023.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("settings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;
        _client = new ApiClient(serverUrl, new HttpClient());
    }
    public async Task<IEnumerable<HigherEducationInstitutionDto>> GetInstitutionsAsync() =>
        await _client.GetInstitutionsAsync();
    public async Task GreateInstitutionAsync(HigherEducationInstitutionDto body) =>
        await _client.CreateInstructonAsync(body);
    public async Task DeleteInstitutionAsync(string id) =>
        await _client.DeleteInstructonAsync(id);
    public async Task UpdateInstitutionAsync(HigherEducationInstitutionDto body) =>
        await _client.UpdateInstitutionAsync(body);


    public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync() =>
        await _client.GetDepartmentsAsync();
    public async Task GreateDepartmentAsync(DepartmentDto body) =>
    await _client.CreateDepartmentAsync(body);
    public async Task DeleteDepartmentAsync(string id) =>
        await _client.DeleteDepartmentAsync(id);
    public async Task UpdateDepartmentAsync(DepartmentDto body) =>
        await _client.UpdateDepartmentAsync(body);


    public async Task<IEnumerable<EducationWorkerDto>> GetEducationWorkersAsync() =>
        await _client.GetEducationWorkersAsync();
    public async Task GreateEducationWorkerAsync(EducationWorkerDto body) =>
        await _client.CreateEducationWorkerAsync(body);
    public async Task DeleteEducationWorkerAsync(string id) =>
        await _client.DeleteEducationWorkerAsync(id);
    public async Task UpdateEducationWorkerAsync(EducationWorkerDto body) =>
        await _client.UpdateEducationWorkerAsync(body);


    public async Task<IEnumerable<FacultyDto>> GetFacultiesAsync() =>
        await _client.GetFacultiesAsync();
    public async Task GreateFacultyAsync(FacultyDto body) =>
        await _client.CreateFacultyAsync(body);
    public async Task DeleteFacultyAsync(string id) =>
        await _client.DeleteFacultyAsync(id);
    public async Task UpdateFacultyAsync(FacultyDto body) =>
        await _client.UpdateFacultyAsync(body);


    public async Task<IEnumerable<GroupOfStudentsDto>> GetGroupOfStudentsAsync() =>
        await _client.GetGroupOfStudentsAsync();
    public async Task CreateGroupOfStudentAsync(GroupOfStudentsDto body) =>
        await _client.CreateGroupOfStudentAsync(body);
    public async Task DeleteGroupOfStudentsAsync(string id) =>
        await _client.DeleteGroupOfStudentsAsync(id);
    public async Task UpdateGroupOfStudentsAsync(GroupOfStudentsDto body) =>
        await _client.UpdateGroupOfStudentsAsync(body);


    public async Task<IEnumerable<InstituteSpecialityDto>> GetInstituteSpecialitiesAsync() =>
        await _client.GetInstituteSpecialitiesAsync();
    public async Task CreateInstituteSpecialityAsync(InstituteSpecialityDto body) =>
        await _client.CreateInstituteSpecialityAsync(body);
    public async Task DeleteInstituteSpecialityAsync(string code, string idInsitution) =>
        await _client.DeleteInstituteSpecialityAsync(code, idInsitution);
    public async Task UpdateInstituteSpecialityAsync(InstituteSpecialityDto body) =>
        await _client.UpdateInstituteSpecialityAsync(body);


    public async Task<IEnumerable<SpecialityDto>> GetSpecialitiesAsync() =>
        await _client.GetSpecialitiesAsync();
    public async Task CreateSpecialityAsync(SpecialityDto body) =>
        await _client.CreateSpecialityAsync(body);
    public async Task DeleteSpecialityAsync(string id) =>
        await _client.DeleteSpecialityAsync(id);
    public async Task UpdateSpecialityAsync(SpecialityDto body) =>
        await _client.UpdateSpecialityAsync(body);


    public async Task<IEnumerable<StudentDto>> GetStudentsAsync() =>
        await _client.GetStudentsAsync();
    public async Task CreateStudentAsync(StudentDto body) =>
        await _client.CreateStudentAsync(body);
    public async Task DeleteStudentAsync(string id) =>
        await _client.DeleteStudentAsync(id);
    public async Task UpdateStudentAsync(StudentDto body) =>
        await _client.UpdateStudentAsync(body);


    // QUERIES

    public async Task<HigherEducationInstitutionDto> GetInstitutionByIdAsync(string id) =>
        await _client.GetInstitutionByIdAsync(id);
    public async Task<IEnumerable<SpecialityDto>> GetPopularSpecialityAsync() =>
        await _client.GetPopularSpecialityAsync();
    public async Task<IEnumerable<HigherEducationInstitutionDto>> GetInstitutionsWithMaxDepartmentsAsync() =>
        await _client.GetInstitutionsWithMaxDepartmentsAsync();
    public async Task<IDictionary<string, int>> GetOwnershipInstitutionAndGroupAsync(
        InstitutionalProperty property) =>
        await _client.GetOwnershipInstitutionAndGroupAsync(property);
    public async Task<IEnumerable<ResponseUniversityStructByProperty>> GetInstitutionStructAsync(
        InstitutionalProperty propertyInstitution, BuildingProperty buildingProperty) =>
        await _client.GetInstitutionStructAsync(propertyInstitution, buildingProperty);
}
