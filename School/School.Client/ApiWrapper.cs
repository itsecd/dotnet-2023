using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace School.Client;

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

    public async Task<ICollection<ClassGetDto>> GetClassesAsync()
    {
        return await _client.GetClassesAsync();
    }

    public async Task<int> PostClassAsync(ClassPostDto classPostDto)
    {
        return await _client.PostClassAsync(classPostDto);
    }

    public async Task PutClassAsync(int id, ClassPostDto classPostDto)
    {
        await _client.PutClassAsync(id, classPostDto);
    }

    public async Task DeleteClassAsync(int id)
    {
        await _client.DeleteClassAsync(id);
    }

    public async Task<ICollection<GradeGetDto>> GetGradesAsync()
    {
        return await _client.GetGradesAsync();
    }

    public async Task<int> PostGradeAsync(GradePostDto gradePostDto)
    {
        return await _client.PostGradeAsync(gradePostDto);
    }

    public async Task PutGradeAsync(int id, GradePostDto gradePostDto)
    {
        await _client.PutGradeAsync(id, gradePostDto);
    }

    public async Task DeleteGradeAsync(int id)
    {
        await _client.DeleteGradeAsync(id);
    }

    public async Task<ICollection<StudentGetDto>> GetStudentsAsync()
    {
        return await _client.GetStudentsAsync();
    }

    public async Task<int> PostStudentAsync(StudentPostDto studentPostDto)
    {
        return await _client.PostStudentAsync(studentPostDto);
    }

    public async Task PutStudentAsync(int id, StudentPostDto studentPosrDto)
    {
        await _client.PutStudentAsync(id, studentPosrDto);
    }

    public async Task DeleteStudentAsync(int id)
    {
        await _client.DeleteStudentAsync(id);
    }

    public async Task<ICollection<SubjectGetDto>> GetSubjectsAsync()
    {
        return await _client.GetSubjectsAsync();
    }

    public async Task<int> PostSubjectAsync(SubjectPostDto subjectPostDto)
    {
        return await _client.PostSubjectAsync(subjectPostDto);
    }

    public async Task PutSubjectAsync(int id, SubjectPostDto subjectPostDto)
    {
        await _client.PutSubjectAsync(id, subjectPostDto);
    }

    public async Task DeleteSubjectAsync(int id)
    {
        await _client.DeleteSubjectAsync(id);
    }
}