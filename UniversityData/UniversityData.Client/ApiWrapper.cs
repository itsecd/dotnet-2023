using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace UniversityData.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var server = configuration.GetSection("ServerURL").Value;

        _client = new ApiClient(server, new HttpClient());
    }

    public Task<ICollection<ConstructionPropertyGetDto>> GetConstructionPropertyAsync()
    {
        return _client.ConstructionPropertyAllAsync();
    }

    public Task<ConstructionPropertyGetDto> AddConstructionPropertyAsync(ConstructionPropertyPostDto constructionProperty)
    {
        return _client.ConstructionPropertyAsync(constructionProperty);
    }

    public Task<ConstructionPropertyPostDto> UpdateConstructionPropertyAsync(int id, ConstructionPropertyPostDto constructionProperty)
    {
        return _client.ConstructionProperty3Async(id, constructionProperty);
    }

    public Task<ConstructionPropertyGetDto> DeleteConstructionPropertyAsync(int id)
    {
        return _client.ConstructionProperty4Async(id);
    }

    public Task<ICollection<UniversityPropertyGetDto>> GetUniversityPropertyAsync()
    {
        return _client.UniversityPropertyAllAsync();
    }

    public Task<UniversityPropertyGetDto> AddUniversityPropertyAsync(UniversityPropertyPostDto universityProperty)
    {
        return _client.UniversityPropertyAsync(universityProperty);
    }

    public Task<UniversityPropertyPostDto> UpdateUniversityPropertyAsync(int id, UniversityPropertyPostDto universityProperty)
    {
        return _client.UniversityProperty3Async(id, universityProperty);
    }

    public Task<UniversityPropertyGetDto> DeleteUniversityPropertyAsync(int id)
    {
        return _client.UniversityProperty4Async(id);
    }

    public Task<ICollection<DepartmentGetDto>> GetDepartmentAsync()
    {
        return _client.DepartmentAllAsync();
    }

    public Task<DepartmentGetDto> AddDepartmentAsync(DepartmentPostDto department)
    {
        return _client.DepartmentAsync(department);
    }

    public Task<DepartmentPostDto> UpdateDepartmentAsync(int id, DepartmentPostDto department)
    {
        return _client.Department3Async(id, department);
    }

    public Task<DepartmentGetDto> DeleteDepartmentAsync(int id)
    {
        return _client.Department4Async(id);
    }

    public Task<ICollection<FacultyGetDto>> GetFacultyAsync()
    {
        return _client.FacultyAllAsync();
    }

    public Task<FacultyGetDto> AddFacultyAsync(FacultyPostDto faculty)
    {
        return _client.FacultyAsync(faculty);
    }

    public Task<FacultyPostDto> UpdateFacultyAsync(int id, FacultyPostDto faculty)
    {
        return _client.Faculty3Async(id, faculty);
    }

    public Task<FacultyGetDto> DeleteFacultyAsync(int id)
    {
        return _client.Faculty4Async(id);
    }

    public Task<ICollection<RectorGetDto>> GetRectorAsync()
    {
        return _client.RectorAllAsync();
    }

    public Task<RectorGetDto> AddRectorAsync(RectorPostDto rector)
    {
        return _client.RectorAsync(rector);
    }

    public Task<RectorPostDto> UpdateRectorAsync(int id, RectorPostDto rector)
    {
        return _client.Rector3Async(id, rector);
    }

    public Task<RectorGetDto> DeleteRectorAsync(int id)
    {
        return _client.Rector4Async(id);
    }

    public Task<ICollection<SpecialtyGetDto>> GetSpecialtyAsync()
    {
        return _client.SpecialtyAllAsync();
    }

    public Task<SpecialtyGetDto> AddSpecialtyAsync(SpecialtyPostDto specialty)
    {
        return _client.SpecialtyAsync(specialty);
    }

    public Task<SpecialtyPostDto> UpdateSpecialtyAsync(int id, SpecialtyPostDto specialty)
    {
        return _client.Specialty3Async(id, specialty);
    }

    public Task<SpecialtyGetDto> DeleteSpecialtyAsync(int id)
    {
        return _client.Specialty4Async(id);
    }

    public Task<ICollection<SpecialtyTableNodeGetDto>> GetSpecialtyTableNodeAsync()
    {
        return _client.SpecialtyTableNodeAllAsync();
    }

    public Task<SpecialtyTableNodeGetDto> AddSpecialtyTableNodeAsync(SpecialtyTableNodePostDto specialtyTableNode)
    {
        return _client.SpecialtyTableNodeAsync(specialtyTableNode);
    }

    public Task<SpecialtyTableNodePostDto> UpdateSpecialtyTableNodeAsync(int id, SpecialtyTableNodePostDto specialtyTableNode)
    {
        return _client.SpecialtyTableNode3Async(id, specialtyTableNode);
    }

    public Task<SpecialtyTableNodeGetDto> DeleteSpecialtyTableNodeAsync(int id)
    {
        return _client.SpecialtyTableNode4Async(id);
    }

    public Task<ICollection<UniversityGetDto>> GetUniversityAsync()
    {
        return _client.UniversityAllAsync();
    }

    public Task<UniversityGetDto> AddUniversityAsync(UniversityPostDto university)
    {
        return _client.UniversityAsync(university);
    }

    public Task<UniversityPostDto> UpdateUniversityAsync(int id, UniversityPostDto university)
    {
        return _client.University3Async(id, university);
    }

    public Task<UniversityGetDto> DeleteUniversityAsync(int id)
    {
        return _client.University4Async(id);
    }

    public Task<UniversityGetDto> GetInformationOfUniversityAsync(string name)
    {
        return _client.AnalyticsAsync(name);
    }
    public Task<UniversityStructureDto> InformationOfStructureAsync(string name)
    {
        return _client.Analytics2Async(name);
    }

    public Task<ICollection<MostPopularSpecialtyDto>> MostPopularSpecialtiesAsync()
    {
        return _client.SpecialtiesAsync();
    }

    public Task<ICollection<UniversityGetDto>> MaxCountDepartmentsAsync()
    {
        return _client.DepartmentsAsync();
    }

    public Task<ICollection<UniversityWithGivenPropertyDto>> UniversityWithPropertyAsync(int universityPropertyId)
    {
        return _client.PropertyAsync(universityPropertyId);
    }

    public Task<ICollection<CountDivisionsWithDifferentProperties>> CountDepartmentsAsync()
    {
        return _client.DivisionsAsync();
    }
}
