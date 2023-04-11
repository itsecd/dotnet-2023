using AutoMapper;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Model, ModelGetDto>();
        CreateMap<Model, ModelPostDto>();

        CreateMap<ModelPostDto, Model>();
    }
}
