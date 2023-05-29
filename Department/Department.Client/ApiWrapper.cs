using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Department.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;

        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public async Task<ICollection<CourseGetDto>> GetCoursesAsync()
    {
        return await _client.CoursesAllAsync();
    }

    public async Task<CourseGetDto> AddCourseAsync(CourseSetDto course)
    {
        return await _client.CoursesAsync(course);
    }

    public async Task UpdateCourseAsync(int id, CourseSetDto course)
    {
        await _client.Courses3Async(id, course);
    }

    public async Task DeleteCourseAsync(int id)
    {
        await _client.Courses4Async(id);
    }

    public async Task<ICollection<GroupGetDto>> GetGroupAsync()
    {
        return await _client.GroupsAllAsync();
    }

    public async Task<GroupGetDto> AddGroupAsync(GroupSetDto group)
    {
        return await _client.GroupsAsync(group);
    }

    public async Task UpdateGroupAsync(int id, GroupSetDto group)
    {
        await _client.Groups3Async(id, group);
    }

    public async Task DeleteGroupAsync(int id)
    {
        await _client.Groups4Async(id);
    }

    public async Task<ICollection<TeacherGetDto>> GetTeachersAsync()
    {
        return await _client.TeachersAllAsync();
    }

    public async Task<TeacherGetDto> AddTeacherAsync(TeacherSetDto teacher)
    {
        return await _client.TeachersAsync(teacher);
    }

    public async Task UpdateTeacherAsync(int id, TeacherSetDto teacher)
    {
        await _client.Teachers3Async(id, teacher);
    }

    public async Task DeleteTeacherAsync(int id)
    {
        await _client.Teachers4Async(id);
    }

    public async Task<ICollection<SubjectGetDto>> GetSubjectsAsync()
    {
        return await _client.SubjectsAllAsync();
    }

    public async Task<SubjectGetDto> AddSubjectAsync(SubjectSetDto subject)
    {
        return await _client.SubjectsAsync(subject);
    }

    public async Task UpdateSubjectAsync(int id, SubjectSetDto subject)
    {
        await _client.Subjects3Async(id, subject);
    }

    public async Task DeleteSubjectAsync(int id)
    {
        await _client.Subjects4Async(id);
    }

    public async Task<ICollection<TeacherGetDto>> CourseProjectTeachersAsync()
    {
        return await _client.CourseProjectTeachersAsync();
    }
}
