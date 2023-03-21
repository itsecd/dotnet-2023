using AutoMapper;
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.Domain.Organization;
using DotNet2023.Domain.Person;
using DotNet2023.WebApi.DtoModels.InstituteDocumentation;
using DotNet2023.WebApi.DtoModels.InstitutionStructure;
using DotNet2023.WebApi.DtoModels.Organization;
using DotNet2023.WebApi.DtoModels.Person;

namespace DotNet2023.WebApi.Service.Mapping;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<HigherEducationInstitution, HigherEducationInstitutionDto>();

        CreateMap<Department, DepartmentDto>();
        CreateMap<Faculty, FacultyDto>();
        CreateMap<GroupOfStudents, GroupOfStudentsDto>();

        CreateMap<InstituteSpeciality, InstituteSpecialityDto>();
        CreateMap<Speciality, SpecialityDto>();

        CreateMap<EducationWorker, EducationWorkerDto>();
        CreateMap<Student, StudentDto>();

        CreateMap<HigherEducationInstitutionDto, HigherEducationInstitution>();
        CreateMap<DepartmentDto, Department>();
        CreateMap<FacultyDto, Faculty>();
        CreateMap<GroupOfStudentsDto, GroupOfStudents>();
        CreateMap<InstituteSpecialityDto, InstituteSpeciality>();
        CreateMap<SpecialityDto, Speciality>();
        CreateMap<EducationWorkerDto, EducationWorker>();
        CreateMap<StudentDto, Student>();
    }
}
