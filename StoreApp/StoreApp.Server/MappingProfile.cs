using AutoMapper;
using StoreApp.Domain;
using StoreApp.Server.Dto;

namespace StoreApp.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CustomerPostDto, Customer>();
        CreateMap<ProductPostDto, Product>();
        CreateMap<StorePostDto, Store>();
    }
}
