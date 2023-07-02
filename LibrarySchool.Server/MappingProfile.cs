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
        CreateMap<ClassType, ClassTypeGetDto>();
        CreateMap<ClassType, ClassTypePostDto>();
        CreateMap<ClassTypePostDto, ClassType>();
        


        CreateMap<Mark, MarkPostDto>();
        CreateMap<MarkPostDto, Mark>();
        CreateMap<Mark, MarkInStudentDto>();
        CreateMap<Mark, MarkGetDto>();

        CreateMap<Student, StudentGetDto>();
        CreateMap<StudentPostDto, Student>();
        CreateMap<Student, StudentPostDto>();

        CreateMap<SubjectPostDto, Subject>();
        CreateMap<Subject, SubjectGetDto>();
        CreateMap<SubjectPostDto, Subject>();
    }
}
