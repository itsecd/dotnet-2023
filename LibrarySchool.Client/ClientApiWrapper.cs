using LibrarySchool.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LibrarySchool.Client;

/// <summary>
/// Class for renaming RESTful methods in server
/// </summary>
public class ClientApiWrapper
{
    private readonly LibrarySchoolClient _schoolClient;

    /// <summary>
    /// Constructor for class ClientApiWrapper
    /// </summary>
    public ClientApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;
        _schoolClient = new LibrarySchoolClient(serverUrl, new System.Net.Http.HttpClient());
    }

    /// <summary>
    /// Get all student
    /// </summary>
    /// <returns></returns>
    public Task<ICollection<StudentGetDto>> GetAllStudentAsync()
    {
        return _schoolClient.StudentAllAsync();
    }

    /// <summary>
    /// Add new student
    /// </summary>
    /// <param name="studentPostDto"></param>
    /// <returns></returns>
    public Task AddStudentAsync(StudentPostDto studentPostDto)
    {
        return _schoolClient.StudentAsync(studentPostDto);
    }

    /// <summary>
    /// Upadate a student
    /// </summary>
    /// <param name="id"></param>
    /// <param name="studentPostDto"></param>
    /// <returns></returns>
    public Task UpdateStudentAsync(int id, StudentPostDto studentPostDto)
    {
        return _schoolClient.Student3Async(id, studentPostDto);
    }

    /// <summary>
    /// Delete student
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteStudentAsync(int id)
    {
        return _schoolClient.Student2Async(id);
    }

    /// <summary>
    /// Get all class
    /// </summary>
    /// <returns></returns>
    public Task<ICollection<ClassTypeGetDto>> GetAllClassTypeAsync()
    {
        return _schoolClient.ClassTypeAllAsync();
    }

    /// <summary>
    /// Add new class
    /// </summary>
    /// <param name="classTypePostDto"></param>
    /// <returns></returns>
    public Task AddClassTypeAsync(ClassTypePostDto classTypePostDto)
    {
        return _schoolClient.ClassTypeAsync(classTypePostDto);
    }

    /// <summary>
    /// Update class
    /// </summary>
    /// <param name="id"></param>
    /// <param name="classTypePostDto"></param>
    /// <returns></returns>
    public Task UpdateClassTypeAsync(int id, ClassTypePostDto classTypePostDto)
    {
        return _schoolClient.ClassType3Async(id, classTypePostDto);
    }

    /// <summary>
    /// Delete class by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteClassTypeAsync(int id)
    {
        return _schoolClient.ClassType4Async(id);
    }

    /// <summary>
    /// Get all subject
    /// </summary>
    /// <returns></returns>
    public Task<ICollection<SubjectGetDto>> GetAllSubjectAsync()
    {
        return _schoolClient.SubjectAllAsync();
    }

    /// <summary>
    /// Add new subject
    /// </summary>
    /// <param name="subjectPostDto"></param>
    /// <returns></returns>
    public Task AddSubjectAsync(SubjectPostDto subjectPostDto)
    {
        return _schoolClient.SubjectAsync(subjectPostDto);
    }

    /// <summary>
    /// Update subject
    /// </summary>
    /// <param name="id"></param>
    /// <param name="subjectPostDto"></param>
    /// <returns></returns>
    public Task UpdateSubjectAsync(int id, SubjectPostDto subjectPostDto)
    {
        return _schoolClient.Subject3Async(id, subjectPostDto); 
    }

    /// <summary>
    /// Delete subject
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteSubjectAsync(int id)
    {
        return _schoolClient.Subject4Async(id);
    }

    /// <summary>
    /// Get all mark
    /// </summary>
    /// <returns></returns>
    public Task<ICollection<MarkGetDto>> GetAllMarkAsync()
    {
        return _schoolClient.MarkAllAsync();
    }

    /// <summary>
    /// Add new mark
    /// </summary>
    /// <param name="markPostDto"></param>
    /// <returns></returns>
    public Task AddMarkAsync(MarkPostDto markPostDto)
    {
        return _schoolClient.MarkAsync(markPostDto);
    }

    /// <summary>
    /// Update mark
    /// </summary>
    /// <param name="id"></param>
    /// <param name="markPostDto"></param>
    /// <returns></returns>
    public Task UpdateMarkAsync(int id, MarkPostDto markPostDto)
    {
        return _schoolClient.Mark3Async(id, markPostDto);
    }

    /// <summary>
    /// Delete mark by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task DeleteMarkAsync(int id)
    {
        return _schoolClient.Mark4Async(id);
    }

    /// <summary>
    /// Query get all student in class by class id
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    public Task<ICollection<StudentGetDto>> GetAllStudentsInClassAsync(int classId)
    {
        return _schoolClient.StudentInClassAsync(classId);
    }

    /// <summary>
    /// Get class by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ClassTypeGetDto> GetClassByIdAsync(int id)
    {
        return _schoolClient.ClassType2Async(id);
    }

    /// <summary>
    /// Query top 5 student
    /// </summary>
    /// <returns></returns>
    public Task<ICollection<StudentGetAverageDto>> TopFiveStudentAsync()
    {
        return _schoolClient.ListTop5StudentAsync();
    }

    /// <summary>
    /// Query top 5 student in period
    /// </summary>
    /// <param name="startPeriod"></param>
    /// <param name="endPeriod"></param>
    /// <returns></returns>
    public Task<ICollection<StudentGetAverageDto>> TopFiveStudentInPeriodAsync(DateTimeOffset startPeriod, DateTimeOffset endPeriod)
    {
        return _schoolClient.Top5InPeriodAsync(startPeriod, endPeriod);
    }

    /// <summary>
    /// Query max, min, average mark by subject id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<MaxMinAverageMarkDto> MaxMinAverageMarkBySubjectAsync(int id)
    {
        return _schoolClient.CountMaxMinAverageAsync(id);
    }
}
