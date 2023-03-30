using AutoMapper;
using LibrarySchool;
using LibrarySchoolServer.Dto;

namespace LibrarySchoolServer;
/// <summary>
/// Mapper to convert between Dto and base type
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Constructor define mapper
    /// </summary>
    public MappingProfile()
    {
        CreateMap<ClassTypeGetDto, ClassType>();
        CreateMap<ClassType, ClassTypeGetDto>();
        CreateMap<ClassType, ClassTypePostDto>();
        CreateMap<ClassTypePostDto, ClassType>();
        CreateMap<Mark, MarkInStudentDto>();
        CreateMap<Mark, MarkPostDto>();
        CreateMap<MarkInStudentDto, Mark>();
        CreateMap<Student, StudentGetDto>();
        CreateMap<StudentPostDto, Student>();
        CreateMap<Student, StudentPostDto>();
        CreateMap<MarkPostDto, Mark>();
        CreateMap<SubjectPostDto, Subject>();
        CreateMap<Student, StudentGetAverageDto>();
    }
}
