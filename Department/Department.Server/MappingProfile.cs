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
    }
}
