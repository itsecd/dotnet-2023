using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Warehouse.Server.Dto;

namespace Warehouse.Server.Controllers;

/// <summary>
///     Controller for get methods which returns a specified data from Warehouse data base
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IDbContextFactory<WarehouseDbContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor for AnalyticsController
    /// </summary>
    public AnalyticsController(IDbContextFactory<WarehouseDbContext> contextFactory, ILogger<AnalyticsController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    ///     Get method which return information about the company's products, sorted by product name
    /// </summary>
    /// <returns>
    ///     Return all products
    /// </returns>
    [HttpGet("all-products")]
    public async Task<ActionResult<List<ProductsGetDto>>> GetAllProducts()
    {
        await using WarehouseDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get all products");
        var request = await (from product in ctx.Products
                             select _mapper.Map<ProductsGetDto>(product)).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the company's products received on the specified day by the recipient of products
    /// </summary>
    /// <param name="supplyDate"> Specific supply date </param>
    /// <returns>
    ///     Return supply with specific date
    /// </returns>
    [HttpGet("supplies-by-specific-date")]
    public async Task<ActionResult<List<SuppliesGetDto>>> SuppliesBySpecificDate(DateTime supplyDate)
    {
        await using WarehouseDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get supplies with specific date");
        var request = await (from products in ctx.Products
                             from supply in products.Supply
                             where supply.SupplyDate == supplyDate
                             orderby supply.Products
                             select _mapper.Map<SuppliesGetDto>(supply)).ToListAsync();
        if (!request.Any())
        {
            _logger.LogInformation("Not found supplies on specific date: {supplyDate}", supplyDate);
            return NotFound($"There are no supplies on date: {supplyDate}");
        }
        else
        {
            _logger.LogInformation("Get information about all supplies on specific date: {supplyDate}", supplyDate);
            return Ok(request);
        }
    }
    /// <summary>
    ///     Get method which return the state of the warehouse at the moment with the numbers of cells of the warehouse and their contents
    /// </summary>
    /// <returns>
    ///     Return warehouse cells and their content
    /// </returns>
    [HttpGet("warehouse-cells-and-their-content")]
    public async Task<ActionResult<List<object>>> WarehouseCellsAndTheirContent()
    {
        await using WarehouseDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Warehouse cells and their content");
        var request = await (from products in ctx.Products
                             from cells in products.WarehouseCell
                             orderby cells.CellNumber
                             select new { 
                                 cells.CellNumber, 
                                 products.Name,
                                 products.Id
                             }).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the organizations that received the maximum volume products for a given period 
    /// </summary>
    /// <param name="minDate"> Minimum date </param>
    /// <param name="maxDate"> Maximum date </param>
    /// <returns>
    ///     Return supplies by specific period
    /// </returns>
    [HttpGet("supplies-by-specific-period")]
    public async Task<ActionResult<List<SuppliesGetDto>>> SuppliesByPeriod(DateTime minDate, DateTime maxDate)
    {
        await using WarehouseDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Supplies by specific period");
        var request = await (from products in ctx.Products
                             from supply in products.Supply
                             where supply.SupplyDate > minDate && supply.SupplyDate < maxDate
                             group supply by new {
                                 supply.CompanyName,
                                 supply.CompanyAddress
                             } into grp
                             select _mapper.Map<SuppliesGetDto>(new {
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
    ///     Return top 5 products
    /// </returns>
    [HttpGet("top-five-products")]
    public async Task<ActionResult<List<ProductsGetDto>>> TopFiveProducts()
    {
        await using WarehouseDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Top 5 products");
        var request = await (from products in ctx.Products
                             orderby products.Quantity descending
                             select _mapper.Map<ProductsGetDto>(products)).Take(5).ToListAsync();
        return Ok(request);
    }
    /// <summary>
    ///     Get method which return information about the quantity of delivered products for each products and each organization
    /// </summary>
    /// <returns>
    ///     Return quantity of delivered products
    /// </returns>
    [HttpGet("quantity-of-delivery-products")]
    public async Task<ActionResult<List<object>>> QuantityOfDeliverdproducts()
    {
        await using WarehouseDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Quantity of delivered products");
        var request = await (from products in ctx.Products
                             from supply in products.Supply
                             select new {
                                 supply.CompanyName, 
                                 supply.CompanyAddress,
                                 products.Name,
                                 products.Id,
                                 supply.Quantity
                             }).ToListAsync();
        return Ok(request);
    }
}