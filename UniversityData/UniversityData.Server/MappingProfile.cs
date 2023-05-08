using AutoMapper;
using UniversityData.Domain;
using UniversityData.Server.Dto;

namespace UniversityData.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DepartmentPostDto, Department>();
        CreateMap<Department, DepartmentGetDto>();
        CreateMap<FacultyPostDto, Faculty>();
        CreateMap<Faculty, FacultyGetDto>();
        CreateMap<RectorPostDto, Rector>();
        CreateMap<Rector, RectorGetDto>();
        CreateMap<SpecialtyPostDto, Specialty>();
        CreateMap<Specialty, SpecialtyGetDto>();
        CreateMap<UniversityPostDto, University>();
        CreateMap<University, UniversityGetDto>();
        CreateMap<SpecialtyTableNodePostDto, SpecialtyTableNode>();
        CreateMap<SpecialtyTableNode, SpecialtyTableNodeGetDto>();
        CreateMap<University, UniversityGetStructureDto>();
        CreateMap<UniversityPropertyPostDto, UniversityProperty>();
        CreateMap<UniversityProperty, UniversityPropertyGetDto>();
        CreateMap<ConstructionPropertyPostDto, ConstructionProperty>();
        CreateMap<ConstructionProperty, ConstructionPropertyGetDto>();
    }
}
