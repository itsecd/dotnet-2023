using AutoMapper;
using Department.Domain;
using Department.Server.Dto;

namespace Department.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Group, GroupGetDto>();
        CreateMap<Group, GroupSetDto>();
        CreateMap<GroupGetDto, Group>();
        CreateMap<GroupSetDto, Group>();

        CreateMap<Teacher, TeacherGetDto>();
        CreateMap<Teacher, TeacherSetDto>();
        CreateMap<TeacherGetDto, Teacher>();
        CreateMap<TeacherSetDto, Teacher>();

        CreateMap<Subject, SubjectGetDto>();
        CreateMap<Subject, SubjectSetDto>();
        CreateMap<SubjectGetDto, Subject>();
        CreateMap<SubjectSetDto, Subject>();

        CreateMap<Course, CourseGetDto>();
        CreateMap<Course, CourseSetDto>();
        CreateMap<CourseGetDto, Course>();
        CreateMap<CourseSetDto, Course>();
    }
}
