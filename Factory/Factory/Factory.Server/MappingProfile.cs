using AutoMapper;
using Factory.Domain;
using Factory.Server.Dto;

namespace Factory.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Enterprise, EnterpriseGetDto>();
        CreateMap<Enterprise, EnterprisePostDto>();
        CreateMap<EnterprisePostDto, Enterprise>();

        CreateMap<Supplier, SupplierGetDto>();
        CreateMap<Supplier, SupplierPostDto>();
        CreateMap<SupplierPostDto, Supplier>();

        CreateMap<Supply, SupplyPostDto>();
    }
}
