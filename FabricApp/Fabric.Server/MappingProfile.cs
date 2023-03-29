using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;

namespace Fabrics.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Fabric, FabricGetDto>();
        CreateMap<Fabric, FabricPostDto>();

        CreateMap<FabricPostDto, Fabric>();
    }
}
