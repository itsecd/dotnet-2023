using AutoMapper;
using MusicMarket;
using MusicMarketServer.Dto;

namespace MusicMarketServer;

/// <summary>
/// Class for mapping types
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerGetDto>();
        CreateMap<Product, ProductGetDto>();
        CreateMap<Purchase, PurchaseGetDto>();
        CreateMap<Seller, SellerGetDto>();

        CreateMap<CustomerPostDto, Customer>().ReverseMap();
        CreateMap<ProductPostDto, Product>().ReverseMap();
        CreateMap<PurchasePostDto, Purchase>().ReverseMap();
        CreateMap<SellerPostDto, Seller>().ReverseMap();
    }
}
