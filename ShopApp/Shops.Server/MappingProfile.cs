using AutoMapper;
using Shops.Domain;
using Shops.Server.Dto;

namespace Shops.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductGetDto>();
        CreateMap<Product, ProductPostDto>().ReverseMap();
        CreateMap<Shop, ShopGetDto>();
        CreateMap<Shop, ShopPostDto>().ReverseMap();
    }
}
