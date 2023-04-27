using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Domain;
using StoreApp.Server.Dto;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : Controller
{
    private readonly IDbContextFactory<StoreAppContext> _contextFactory;
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IMapper _mapper;

    public AnalyticsController(IDbContextFactory<StoreAppContext> contextFactory, ILogger<AnalyticsController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Display information about all products in a given store
    /// </summary>
    /// <param name="storeId">
    /// StoreId
    /// </param>
    /// <returns>
    /// JSON products
    /// </returns>
    [HttpGet("/ProductsInSpecifiedStore/{storeId}")]
    public async Task<IActionResult> ProductsInSpecifiedStore(int storeId)
    {
        _logger.LogInformation($"Get information about products in store with ID: {storeId}");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from ps in ctx.ProductStores
                            join p in ctx.Products on ps.ProductId equals p.ProductId
                            join s in ctx.Stores on ps.StoreId equals s.StoreId
                            where s.StoreId == storeId && ps.Quantity > 0
                            select _mapper.Map<ProductGetDto>(p)).ToListAsync();

        return Ok(result);
    }


    /// <summary>
    /// For a given product, display a list of stores where it is located in availability
    /// </summary>
    /// <param name="productId">
    /// ProductId
    /// </param>
    /// <returns>
    /// JSON stores
    /// </returns>
    [HttpGet("/StoresWithProduct/{productId}")]
    public async Task<IActionResult> StoresWithProduct(int productId)
    {
        _logger.LogInformation($"Get list of stores where product with ID {productId} is located in availability");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from ps in ctx.ProductStores
                            join p in ctx.Products on ps.ProductId equals p.ProductId
                            join s in ctx.Stores on ps.StoreId equals s.StoreId
                            where ps.Quantity > 0 && p.ProductId == productId
                            select _mapper.Map<StoreGetDto>(s)).ToListAsync();

        return Ok(result);
    }


    /// <summary>
    /// Display information about the average cost of goods of each product group for each store.
    /// </summary>
    /// <returns>
    /// JSON (Store, Avg, Category)
    /// </returns>
    [HttpGet("/InfomationAboutAvgPrice")]
    public async Task<IActionResult> InfomationAboutAvgPrice()
    {
        _logger.LogInformation("Get information about the average cost of goods of each product group for each store.");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from ps in ctx.ProductStores
                            join p in ctx.Products on ps.ProductId equals p.ProductId
                            join s in ctx.Stores on ps.StoreId equals s.StoreId
                            group new { p, s } by new { p.ProductGroup, s.StoreId } into grp
                            select new
                            {
                                StoreId = grp.Key.StoreId,
                                ProductCategory = grp.Key.ProductGroup,
                                AveragePrice = grp.Average(x => x.p.ProductPrice)
                            }).ToListAsync();

        return Ok(result);
    }


    /// <summary>
    /// Display the top 5 purchases by total sale amount.
    /// </summary>
    /// <returns>
    /// JSON sales
    /// </returns>
    [HttpGet("/TopSales")]
    public async Task<IActionResult> TopSales()
    {
        _logger.LogInformation("Get top 5 purchases by total sale amount.");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await ((from sa in ctx.Sales
                             orderby sa.Sum descending
                             select _mapper.Map<SaleGetDto>(sa)).Take(5)).ToListAsync();
        return Ok(result);
    }


    /// <summary>
    /// Display all information about products that exceed the storage date limit, indicating the store
    /// </summary>
    /// <returns>
    /// JSON store-product
    /// </returns>
    [HttpGet("/ExpiredProducts")]
    public async Task<IActionResult> ExpiredProducts()
    {
        _logger.LogInformation("Display all information about products that exceed the storage date limit, indicating the store");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from ps in ctx.ProductStores
                            join p in ctx.Products on ps.ProductId equals p.ProductId
                            join s in ctx.Stores on ps.StoreId equals s.StoreId
                            where p.DateStorage < DateTime.Now
                            select new
                            {
                                StoreName = s.StoreName,
                                StoreAddress = s.StoreAddress,
                                ProductId = p.ProductId,
                                ProductGroup = p.ProductGroup,
                                ProductName = p.ProductName,
                                ProductWeight = p.ProductWeight,
                                ProductType = p.ProductType,
                                ProductPrice = p.ProductPrice,
                                DateStorage = p.DateStorage
                            }).ToListAsync();
        return Ok(result);
    }


    /// <summary>
    /// Display a list of stores that sold goods for the month amount in excess of the
    /// </summary>
    /// <param name="minSalesAmount">
    /// Minimal amount
    /// </param>
    /// <returns>
    /// JSON store-amount
    /// </returns>
    [HttpGet("/StoresWithAmountMoreThen/{minSalesAmount}")]
    public async Task<IActionResult> StoresWithAmountMoreThen(double minSalesAmount)
    {
        if (minSalesAmount.GetType() != typeof(double))
        {
            return BadRequest("Invalid minSalesAmount parameter");
        }
        else
        {
            _logger.LogInformation($"Display a list of stores that sold goods for the month amount more then {minSalesAmount}");
            using var ctx = await _contextFactory.CreateDbContextAsync();
            DateTime startDate = DateTime.Now.AddMonths(-2);
            var result = await (from sale in ctx.Sales
                                where sale.DateSale >= startDate
                                group sale by sale.StoreId into storeGroup
                                select new
                                {
                                    StoreId = storeGroup.Key,
                                    TotalSales = storeGroup.Sum(sale => sale.Sum),
                                } into storeSales
                                where storeSales.TotalSales >= minSalesAmount
                                select new { StoreId = storeSales.StoreId, TotalSales = storeSales.TotalSales }).ToListAsync();
            return Ok(result);
        }
    }
}
