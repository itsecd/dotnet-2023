using AutoMapper;
using Factory.Model;
using Factory.Server.Dto;

namespace Factory.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Enterprise, EnterpriseGetDto>();
        CreateMap<EnterprisePostDto, Enterprise>();

        CreateMap<Supplier, SupplierGetDto>();
        CreateMap<SupplierPostDto, Supplier>();

        CreateMap<Supply, SupplyGetDto>();
        CreateMap<SupplyPostDto, Supply>();

        CreateMap<TypeIndustry, TypeIndustryGetDto>();
        CreateMap<OwnershipForm, OwnershipFormGetDto>();
    }
}
