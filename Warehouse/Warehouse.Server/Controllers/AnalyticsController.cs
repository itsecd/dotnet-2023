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
    private readonly IDbContextFactory<WarehouseDbContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for AnalyticsController
    /// </summary>
    /// <param name="contextFactory"></param>
    /// <param name="logger"></param>
    /// <param name="warehouseRepository"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(IDbContextFactory<WarehouseDbContext> contextFactory, ILogger<AnalyticsController> logger, IWarehouseRepository warehouseRepository, IMapper mapper)
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
    ///     All products
    /// </returns>
    [HttpGet("all-products")]
    public async Task<ActionResult<IEnumerable<ProductsGetDto>>> GetAllProducts()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get all products");
        var request = (from product in ctx.Products
                       select _mapper.Map<ProductsGetDto>(product)).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the company's products received on the specified day by the recipient of products
    /// </summary>
    /// <returns>
    ///     Supply with specific date
    /// </returns>
    [HttpGet("supplies-by-specific-date")]
    public async Task<ActionResult<IEnumerable<SuppliesGetDto>>> SuppliesBySpecificDate()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get supplies with specific date");
        var request = (from products in ctx.Products
                       from supply in products.Supply
                       where supply.SupplyDate == new DateTime(2023, 02, 11)
                       orderby supply.Products
                       select _mapper.Map<SuppliesGetDto>(supply)).ToListAsync();
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
        var request = (from products in ctx.Products
                       from cell in products.WarehouseCell
                       orderby cell.CellNumber
                       select _mapper.Map<WarehouseCellsDto>(new { number = cell.CellNumber, productsTitle = products.Name, productsQuantity = products.Quantity })).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the organizations that received the maximum volume products for a given period 
    /// </summary>
    /// <returns>
    ///     Supplies by specific period
    /// </returns>
    [HttpGet("supplies-by-specific-period")]
    public async Task<ActionResult<IEnumerable<SuppliesGetDto>>> SuppliesByPeriod()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Supplies by specific period");
        var request = (from products in ctx.Products
                       from supply in products.Supply
                       where supply.SupplyDate > new DateTime(2023, 02, 1) && supply.SupplyDate < new DateTime(2023, 03, 15)
                       group supply by new
                       {
                           supply.CompanyName,
                           supply.CompanyAddress
                       } into grp
                       select _mapper.Map<SuppliesGetDto>(new
                       {
                           grp.Key.CompanyName,
                           grp.Key.CompanyAddress,
                           quantity = grp.Sum(x => x.Quantity)
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
    public async Task<ActionResult<IEnumerable<ProductsGetDto>>> TopFiveProducts()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Top 5 products");
        var request = (from products in ctx.Products
                       orderby products.Quantity descending
                       select _mapper.Map<ProductsGetDto>(products)).Take(5).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the quantity of delivered products for each products and each organization
    /// </summary>
    /// <returns>
    ///     Quantity of delivered products
    /// </returns>
    [HttpGet("quantity-of-delivery-products")]
    public async Task<ActionResult<IEnumerable<SuppliesGetDto>>> QuantityOfDeliverdproducts()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Quantity of delivered products");
        var request = (from products in ctx.Products
                       from supply in products.Supply
                       group supply by new
                       {
                           supply.CompanyName,
                           supply.CompanyAddress,
                           products.Id,
                           products.Name
                       } into grp
                       select _mapper.Map<SuppliesGetDto>(new
                       {
                           grp.Key.CompanyName,
                           grp.Key.CompanyAddress,
                           grp.Key.Id,
                           grp.Key.Name,
                           quantity = grp.Sum(x => x.Quantity)
                       })).ToListAsync();
        return Ok(request);
    }
}