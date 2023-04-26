using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Warehouse.Server.Dto;
using Warehouse.Server.Repository;

namespace Warehouse.Server.Controllers;

/// <summary>
///     Controller for get methods which returns a specified data from Warehouse data base
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IDbContextFactory<WarehouseContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for AnalyticsController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="logger"></param>
    /// <param name="warehouseRepository"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(IDbContextFactory<WarehouseContext> contextFactory, ILogger<AnalyticsController> logger, IWarehouseRepository warehouseRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _warehouseRepository = warehouseRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///     Get method which return information about the company's products, sorted by product name
    /// </summary>
    /// <returns>
    ///     All goods
    /// </returns>
    [HttpGet("all-goods")]
    public async Task<ActionResult<IEnumerable<GoodsGetDto>>> GetAllGoods()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get all goods");
        var request = (from good in ctx.Products
                       select _mapper.Map<GoodsGetDto>(good)).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the company's products received on the specified day by the recipient of products
    /// </summary>
    /// <returns>
    ///     Supply with specific date
    /// </returns>
    [HttpGet("goods-with-specific-date")]
    public async Task<ActionResult<IEnumerable<SupplyGetDto>>> SupplyWithSpecificDate()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get supply with specific date");
        var request = (from goods in ctx.Products
                       from supply in goods.Supply
                       where supply.SupplyDate == new DateTime(2023, 02, 11)
                       orderby supply.Goods
                       select _mapper.Map<SupplyGetDto>(supply)).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return the state of the warehouse at the moment with the numbers of cells of the warehouse and their contents
    /// </summary>
    /// <returns>
    ///     Warehouse cells and their content
    /// </returns>
    [HttpGet("warehouse-cells-and-their-content")]
    public async Task<ActionResult<IEnumerable<WarehouseCellsDto>>> WarehouseCellsAndTheirContent()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Warehouse cells and their content");
        var request = (from goods in ctx.Products
                       from cell in goods.WarehouseCell
                       orderby cell.CellNumber
                       select _mapper.Map<WarehouseCellsDto>(new { number = cell.CellNumber, goodsTitle = goods.Name, goodsCount = goods.ProductCount})).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the organizations that received the maximum volume products for a given period 
    /// </summary>
    /// <returns>
    ///     Supplies by specific period
    /// </returns>
    [HttpGet("supply-by-specific-period")]
    public async Task<ActionResult<IEnumerable<SupplyGetDto>>> SupplyByPeriod()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Supply by specific period");
        var request = (from goods in ctx.Products
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
                       })).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return the top 5 products by stock availability
    /// </summary>
    /// <returns>
    ///     Top 5 products
    /// </returns>
    [HttpGet("top-five-products")]
    public async Task<ActionResult<IEnumerable<GoodsGetDto>>> TopFiveProducts()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Top 5 products");
        var request = (from goods in ctx.Products
                       orderby goods.ProductCount descending
                       select _mapper.Map<GoodsGetDto>(goods)).Take(5).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the quantity of delivered goods for each goods and each organization
    /// </summary>
    /// <returns>
    ///     Quantity of delivered goods
    /// </returns>
    [HttpGet("quantity-of-delivery-goods")]
    public async Task<ActionResult<IEnumerable<SupplyGetDto>>> QuantityOfDeliverdGoods()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Quantity of delivered goods");
        var request = (from goods in ctx.Products
                       from supply in goods.Supply
                       group supply by new
                       {
                           supply.CompanyName,
                           supply.CompanyAddress,
                           goods.Id,
                           goods.Name
                       } into grp
                       select _mapper.Map<SupplyGetDto>(new
                       {
                           grp.Key.CompanyName,
                           grp.Key.CompanyAddress,
                           grp.Key.Id,
                           grp.Key.Name,
                           quntity = grp.Sum(x => x.SupplyCount)
                       })).ToListAsync();
        return Ok(request);
    }
}