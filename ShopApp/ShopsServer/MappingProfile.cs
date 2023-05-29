using AutoMapper;
using ShopsDomain;
using ShopsServer.Dto;

namespace ShopsServer;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductGetDto>();
        CreateMap<Product, ProductPostDto>().ReverseMap();
        CreateMap<Shop, ShopGetDto>();
        CreateMap<Shop, ShopPostDto>().ReverseMap();
        CreateMap<Customer, CustomerGetDto>();
        CreateMap<Customer, CustomerPostDto>().ReverseMap();
        CreateMap<ProductGroup, ProductGroupGetDto>();
        CreateMap<ProductGroup, ProductGroupPostDto>().ReverseMap();
        CreateMap<ProductQuantity, ProductQuantityGetDto>();
        CreateMap<ProductQuantity, ProductQuantityPostDto>().ReverseMap();
        CreateMap<PurchaseRecord, PurchaseRecordGetDto>();
        CreateMap<PurchaseRecord, PurchaseRecordPostDto>().ReverseMap();
    }
}
