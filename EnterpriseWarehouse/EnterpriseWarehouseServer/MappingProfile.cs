using AutoMapper;
using Enterprise.Data;
using EnterpriseWarehouseServer.Dto;

namespace EnterpriseWarehouseServer;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductPostDto, Product>();
        CreateMap<ProductPostDto, ProductGetDto>();
        CreateMap<StorageCell, StorageCellGetDto>();
        CreateMap<StorageCellPostDto, StorageCell>();
        CreateMap<StorageCellPostDto, StorageCellGetDto>();
        CreateMap<InvoiceGetDto, InvoicePostDto>();
    }
}