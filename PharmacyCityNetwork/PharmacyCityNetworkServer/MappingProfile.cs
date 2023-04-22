using AutoMapper;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server;

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
    }
}
