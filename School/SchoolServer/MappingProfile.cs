using AutoMapper;
using SchoolServer.Dto;
using School.Classes;

namespace SchoolServer;

/// <summary>
/// Класс, позволяющий преобразовывать некие типы в другие типы
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Class, ClassGetDto>();
        CreateMap<ClassGetDto, Class>();
        CreateMap<ClassPostDto, Class>();

        CreateMap<Subject, SubjectGetDto>();
        CreateMap<SubjectGetDto, Subject>();

        CreateMap<Student, StudentGetDto>();
        CreateMap<StudentGetDto, Student>();

        CreateMap<GradeGetDto, Grade>();
        CreateMap<Grade, GradeGetDto>();
    }
}
