using Warehouse.Server.Dto;
using Warehouse.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Execution;
using Warehouse.Domain;

namespace Warehouse.Server.Controllers;

/// <summary>
/// Controller for get methods which returns a specified data from Warehouse data base
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IWarehouseRepository warehouseRepository, IMapper mapper)
    {
        _logger = logger;
        _warehouseRepository = warehouseRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method which return information about the company's products, sorted by product name
    /// </summary>
    /// <returns>All goods</returns>
    [HttpGet("all-goods")]
    public IEnumerable<GoodsGetDto> GetAllGoods()
    {
        _logger.LogInformation("Get all goods");
        var request = (from good in _warehouseRepository.Goods
                       select _mapper.Map<GoodsGetDto>(good));
        return request;
    }
    /// <summary>
    /// Get method which return information about the company's products received on the specified day by the recipient of products
    /// </summary>
    /// <returns>Supply with specific date</returns>
    [HttpGet("goods-with-specific-date")]
    public IEnumerable<SupplyGetDto> SupplyWithSpecificDate()
    {
        _logger.LogInformation("Get supply with specific date");
        var request = (from goods in _warehouseRepository.Goods
                       from supply in supply.Goods
                       where supply.SupplyDate == new DateTime(2023, 02, 11)
                       orderby supply.Goods
                       select _mapper.Map<SupplyGetDto>(supply));
        return request;
    }
    /// <summary>
    /// Get method which return the state of the warehouse at the moment with the numbers of cells of the warehouse and their contents
    /// </summary>
    /// <returns>Warehouse cells and their content</returns>
    [HttpGet("warehouse-cells-and-their-content")]
    public IEnumerable<WarehouseCellsGetDto> WarehouseCellsAndTheirContent()
    {
        _logger.LogInformation("Warehouse cells and their content");
        var request = (from goods in _warehouseRepository.Goods
                       from cell in goods.WarehouseCells
                       orderby cell.CellNumber
                       select _mapper.Map<WarehouseCellsGetDto>(new{ number = cell.CellNumber, goodsTitle = goods.Name, goodsCount = goods.ProductCount }));
        return request;
    }
    /// <summary>
    /// Get method which return information about the organizations that received the maximum volume products for a given period 
    /// </summary>
    /// <returns>Supply by period</returns>
    [HttpGet("supply-by-period")]
    public IEnumerable<SupplyGetDto> SupplyByPeriod()
    {
        _logger.LogInformation("Supply by period");
        var request = (from goods in _warehouseRepository.Goods
                       from supply in goods.Supply
                       where supply.SupplyDate > new DateTime(2023, 02, 1) && supply.SupplyDate < new DateTime(2023, 03, 15)
                       group supply by new
                       {
                           supply.CompanyName,
                           supply.CompanyAddress
                       } into grp
                       select _mapper.Map<SupplyGetDto>(new
                       {
                           grp.Key.CompanyName,
                           grp.Key.CompanyAddress,
                           goodsCount = grp.Sum(x => x.SupplyCount)
                       }));
        return request;
    }
    /// <summary>
    /// Get method which return the top 5 products by stock availability
    /// </summary>
    /// <returns>Top 5 products</returns>
    [HttpGet("top-five-products")]
    public IEnumerable<GoodsGetDto> TopFiveProducts()
    {
        _logger.LogInformation("Top 5 products");
        var request = (from goods in _warehouseRepository.Goods
                       orderby goods.ProductCount descending
                       select _mapper.Map<GoodsGetDto>(goods)).Take(5);
        return request;
    }
    /// <summary>
    /// Get method which return information about the quantity of delivered goods for each goods and each organization
    /// </summary>
    /// <returns>Quantity of delivered goods</returns>
    [HttpGet("quantity-of-delivery-goods")]
    public IEnumerable<SupplyGetDto> QuantityOfDeliverdGoods()
    {
        _logger.LogInformation("Quantity of delivered goods");
        var request = (from goods in _warehouseRepository.Goods
                                        from supply in goods.Supply
                                        group supply by new
                                        {
                                            supply.CompanyName,
                                            supply.CompanyAddress,
                                            goods.Id,
                                            goods.Name
                                        } into grp
                                        select _mapper.Map<GoodsGetDto>(new
                                        {
                                            grp.Key.CompanyName,
                                            grp.Key.CompanyAddress,
                                            grp.Key.Id,
                                            grp.Key.Name,
                                            quntity = grp.Sum(x => x.SupplyCount)
                                        }));
        return request;
    }
}