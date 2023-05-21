using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SelectionCommittee.Client;

public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        _client = new ApiClient(configuration.GetSection("ServerUrl").Value, new HttpClient());
    }

    public async Task<ICollection<EnrolleeDtoGet>> GetEnrolleesAsync()
    {
        return await _client.GetEnrolleesAsync();
    }

    public async Task<int> AddEnrolleeAsync(EnrolleeDtoPostOrPut enrolleeDtoPostOrPut)
    {
        return await _client.AddEnrolleeAsync(enrolleeDtoPostOrPut);
    }

    public async Task UpdateEnrolleeAsync(int id, EnrolleeDtoPostOrPut enrolleeDtoPostOrPut)
    {
        await _client.UpdateEnrolleeAsync(id, enrolleeDtoPostOrPut);
    }

    public async Task DeleteEnrolleeAsync(int id)
    {
        await _client.DeleteEnrolleeAsync(id);
    }

    public async Task<ICollection<ExamResultDtoGet>> GetExamResultsAsync()
    {
        return await _client.GetExamResultsAsync();
    }

    public async Task<int> AddExamResultAsync(ExamResultDtoPostOrPut examResultDtoPostOrPut)
    {
        return await _client.AddExamResultAsync(examResultDtoPostOrPut);
    }

    public async Task UpdateExamResultAsync(int id, ExamResultDtoPostOrPut examResultDtoPostOrPut)
    {
        await _client.UpdateExamResultAsync(id, examResultDtoPostOrPut);
    }

    public async Task DeleteExamResultAsync(int id)
    {
        await _client.DeleteExamResultAsync(id);
    }

    public async Task<ICollection<FacultyDtoGet>> GetFacultiesAsync()
    {
        return await _client.GetFacultiesAsync();
    }

    public async Task<int> AddFacultyAsync(FacultyDtoPostOrPut facultyDtoPostOrPut)
    {
        return await _client.AddFacultyAsync(facultyDtoPostOrPut);
    }

    public async Task UpdateFacultyAsync(int id, FacultyDtoPostOrPut facultyDtoPostOrPut)
    {
        await _client.UpdateFacultyAsync(id, facultyDtoPostOrPut);
    }

    public async Task DeleteFacultyAsync(int id)
    {
        await _client.DeleteFacultyAsync(id);
    }

    public async Task<ICollection<SpecializationDtoGet>> GetSpecializationsAsync()
    {
        return await _client.GetSpecializationsAsync();
    }

    public async Task<int> AddSpecializationAsync(SpecializationDtoPostOrPut specializationDtoPostOrPut)
    {
        return await _client.AddSpecializationAsync(specializationDtoPostOrPut);
    }

    public async Task UpdateSpecializationAsync(int id, SpecializationDtoPostOrPut specializationDtoPostOrPut)
    {
        await _client.UpdateSpecializationAsync(id, specializationDtoPostOrPut);
    }

    public async Task DeleteSpecializationAsync(int id)
    {
        await _client.DeleteSpecializationAsync(id);
    }
}
