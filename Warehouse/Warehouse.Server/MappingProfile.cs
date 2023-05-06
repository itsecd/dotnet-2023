using AutoMapper;
using Warehouse.Domain;
using Warehouse.Server.Dto;

namespace Warehouse.Server;

/// <summary>
///     Class to mapping types
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WarehouseCells, WarehouseCellsDto>();
        CreateMap<WarehouseCellsDto, WarehouseCells>();

        CreateMap<Supplies, SuppliesGetDto>();
        CreateMap<Supplies, SuppliesPostDto>();
        CreateMap<SuppliesPostDto, Supplies>();

        CreateMap<Products, ProductsPostDto>();
        CreateMap<Products, ProductsGetDto>();
        CreateMap<ProductsPostDto, Products>();
    }
}