using AutoMapper;
using Enterprise.Data;
using EnterpriseWarehouseServer.Dto;

namespace EnterpriseWarehouseServer;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<ProductPostDto, Product>().ReverseMap();
        CreateMap<ProductPostDto, ProductGetDto>().ReverseMap();
        CreateMap<Invoice, InvoiceGetDto>().ReverseMap();
        CreateMap<InvoicePostDto, Invoice>().ReverseMap();
        CreateMap<InvoicePostDto, InvoiceGetDto>().ReverseMap();
        CreateMap<StorageCell, StorageCellGetDto>().ReverseMap();
        CreateMap<StorageCellPostDto, StorageCell>().ReverseMap();
        CreateMap<StorageCellPostDto, StorageCellGetDto>().ReverseMap();
        CreateMap<StorageCell, StorageCellGetDto>().ReverseMap();
        CreateMap<StorageCellPostDto, StorageCell>().ReverseMap();
        CreateMap<StorageCellPostDto, StorageCellGetDto>().ReverseMap();
    }
}
