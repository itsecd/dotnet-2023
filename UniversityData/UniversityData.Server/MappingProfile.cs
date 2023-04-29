using AutoMapper;
using UniversityData.Domain;
using UniversityData.Server.Dto;

namespace UniversityData.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Department, DepartmentPostDto>();
        CreateMap<Faculty, FacultyPostDto>();
        CreateMap<Rector, RectorPostDto>();
        CreateMap<Specialty, SpecialtyPostDto>();
        CreateMap<University, UniversityPostDto>();
        CreateMap<University, UniversityGetDto>();
        CreateMap<SpecialtyTableNode, SpecialtyTableNodePostDto>();
        CreateMap<SpecialtyTableNode, SpecialtyTableNodeGetDto>();
        CreateMap<DepartmentPostDto, Department>();
        CreateMap<FacultyPostDto, Faculty>();
        CreateMap<RectorPostDto, Rector>();
        CreateMap<SpecialtyPostDto, Specialty>();
        CreateMap<UniversityPostDto, University>();
        CreateMap<SpecialtyTableNodePostDto, SpecialtyTableNode>();
        CreateMap<University, UniversityGetStructureDto>();
        CreateMap<UniversityProperty, UniversityPropertyDto>();
        CreateMap<UniversityPropertyDto, UniversityProperty>();
        CreateMap<ConstructionProperty, ConstructionPropertyDto>();
        CreateMap<ConstructionPropertyDto, ConstructionProperty>();
    }
}
