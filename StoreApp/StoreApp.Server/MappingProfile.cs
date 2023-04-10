using AutoMapper;
using StoreApp.Domain;
using StoreApp.Server.Dto;

namespace StoreApp.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerGetDto>();
        CreateMap<CustomerPostDto, Customer>();

        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductPostDto, Product>();

        CreateMap<ProductStore, ProductStoreGetDto>();
        CreateMap<ProductStorePostDto, ProductStore>();

        CreateMap<Store, StoreGetDto>();
        CreateMap<StorePostDto, Store>();

        CreateMap<Sale, SaleGetDto>();
        CreateMap<SalePostDto, Sale>();
    }
}
