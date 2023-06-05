using AutoMapper;
using Enterprise.Data;
using EnterpriseWarehouse.Server.Dto;

namespace EnterpriseWarehouse.Server;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductPostDto, Product>();
        CreateMap<ProductPostDto, ProductGetDto>();
        CreateMap<InvoiceGetDto, InvoicePostDto>();
        CreateMap<InvoiceContent, InvoiceContentGetDto>();
        CreateMap<InvoiceContentPostDto, InvoiceContent>();
    }
}