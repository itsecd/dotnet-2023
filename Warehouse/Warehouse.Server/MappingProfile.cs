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
        CreateMap<WarehouseCells, WarehouseCellsGetDto>();
        CreateMap<WarehouseCells, WarehouseCellsPostDto>();
        CreateMap<WarehouseCellsPostDto, WarehouseCells>();

        CreateMap<Supply, SupplyGetDto>();
        CreateMap<Supply, SupplyPostDto>();
        CreateMap<SupplyPostDto, Supply>();

        CreateMap<Goods, GoodsPostDto>();
        CreateMap<Goods, GoodsGetDto>();
        CreateMap<GoodsPostDto, Goods>();
    }
}