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
        CreateMap<Provider, ProviderGetDto>();
        CreateMap<Provider, ProviderPostDto>();
        CreateMap<Shipment, ShipmentGetDto>();
        CreateMap<Shipment, ShipmentPostDto>();

        CreateMap<FabricPostDto, Fabric>();
        CreateMap<ProviderPostDto, Provider>();
        CreateMap<ShipmentPostDto, Shipment>();
    }
}
