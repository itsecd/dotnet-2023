using AutoMapper;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server;
/// <summary>
/// Class to mapping types
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Manufacturer, ManufacturerGetDto>();
        CreateMap<Manufacturer, ManufacturerPostDto>();
        CreateMap<ManufacturerPostDto, Manufacturer>();

        CreateMap<Group, GroupGetDto>();
        CreateMap<Group, GroupPostDto>();
        CreateMap<GroupPostDto, Group>();

        CreateMap<Pharmacy, PharmacyGetDto>();
        CreateMap<Pharmacy, PharmacyPostDto>();
        CreateMap<PharmacyPostDto, Pharmacy>();

        CreateMap<PharmaGroup, PharmaGroupGetDto>();
        CreateMap<PharmaGroup, PharmaGroupPostDto>();
        CreateMap<PharmaGroupPostDto, PharmaGroup>();

        CreateMap<Product, ProductGetDto>();
        CreateMap<Product, ProductPostDto>();
        CreateMap<ProductPostDto, Product>();

        CreateMap<ProductPharmacy, ProductPharmacyGetDto>();
        CreateMap<ProductPharmacy, ProductPharmacyPostDto >();
        CreateMap<ProductPharmacyPostDto, ProductPharmacy>();

        CreateMap<ProductPharmaGroup, ProductPharmaGroupGetDto>();
        CreateMap<ProductPharmaGroup, ProductPharmaGroupPostDto>();
        CreateMap<ProductPharmaGroupPostDto, ProductPharmaGroup>();

        CreateMap<Sale, SaleGetDto>();
        CreateMap<Sale, SalePostDto>();
        CreateMap<SalePostDto, Sale>();
    }
}
