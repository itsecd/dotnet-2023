using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyCityNetwork.Server.Dto;

namespace PharmacyCityNetwork.Server.Controllers;

/// <summary>
/// Analytics controller for queries
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IDbContextFactory<PharmacyCityNetworkDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<PharmacyCityNetworkDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    ///Get all products from pharmacy 
    /// </summary>
    /// <param name="pharmacyId">Prarmacy Id</param>
    /// <returns>All products from pharmacy</returns>
    [HttpGet("all-products-from-pharmacy")]
    public async Task<ActionResult<List<ProductGetDto>>> GetAllProductFromPharmacy(uint pharmacyId)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get all product from pharmacy");
        var request = await (from pharmacy in ctx.Pharmacys
                             from productPharmacy in pharmacy.ProductPharmacys
                             where pharmacy.Id == pharmacyId
                             orderby productPharmacy.Product.ProductName
                             select _mapper.Map<ProductGetDto>(productPharmacy.Product)).ToListAsync();
        if (!request.Any())
        {
            _logger.LogInformation("Not found products from pharmacy {pharmacyId}", pharmacyId);
            return NotFound($"There are no products in this pharmacy {pharmacyId}");
        }
        else
        {
            _logger.LogInformation("Get information about all product from pharmacy: {pharmacyId}", pharmacyId);
            return Ok(request);
        }

    }
    /// <summary>
    ///Get products from pharmacy 
    /// </summary>
    /// <param name="productId">Product Id</param>
    /// <returns>Products from pharmacy</returns>
    [HttpGet("products-from-pharmacy")]
    public async Task<ActionResult<List<dynamic>>> GetProductsFromPharmacy(uint productId)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get products from pharmacy");
        var request = await (from pharmacy in ctx.Pharmacys
                             from productPharmacy in pharmacy.ProductPharmacys
                             where productPharmacy.Product.Id == productId
                             group productPharmacy by productPharmacy.Pharmacy.PharmacyName into g
                             select new
                             {
                                 Pharmacy = g.Key,
                                 Count = (from pharmacy in ctx.Pharmacys
                                          from productPharmacy in pharmacy.ProductPharmacys
                                          where productPharmacy.Pharmacy.PharmacyName.Equals(g.Key)
                                          where productPharmacy.Product.Id == productId
                                          select productPharmacy.ProductCount).FirstOrDefault()
                             }).ToListAsync();
        if (!request.Any())
        {
            _logger.LogInformation("Not found pharmacys with product with {productId}", productId);
            return NotFound($"There are no pharmacys with this product {productId}");
        }
        else
        {
            _logger.LogInformation("Get information about  product from pharmacy: {productId}", productId);
            return Ok(request);
        }
    }
    /// <summary>
    ///Get average cost for each farmGroup and pharmacy
    /// </summary>
    /// <returns>Average cost for each farmGroup and pharmacy</returns>
    [HttpGet("farm-group")]
    public async Task<ActionResult<List<dynamic>>> GetFarmGroup()
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get average cost for each farmGroup and pharmacy");
        var request = await (from pharmaGroup in ctx.PharmaGroups
                             from productPharmaGroup in pharmaGroup.ProductPharmaGroups
                             from productPharmacy in productPharmaGroup.Product.ProductPharmacys
                             group productPharmacy by new
                             {
                                 productPharmaGroup.PharmaGroup.Id,
                                 productPharmacy.Pharmacy.PharmacyName
                             } into pharmacyGroups
                             select new
                             {
                                 PharmaGroup = pharmacyGroups.Key.Id,
                                 Pharmacy = pharmacyGroups.Key.PharmacyName,
                                 ProductCost = pharmacyGroups.Average(s => s.ProductCost)
                             }
               ).ToListAsync();
        _logger.LogInformation("Get information about average cost for each farmGroup and pharmacy");
        return Ok(request);
    }
    /// <summary>
    ///Get top five pharmacy
    /// </summary>
    /// <param name="dateOne">Beginning of the period</param> 
    /// <param name="dateTwo">End of the period</param>
    /// <returns>Top five pharmacy</returns>
    [HttpGet("top-five-pharmacy")]
    public async Task<ActionResult<List<dynamic>>> GetTopFivePharmacy(DateTime dateOne, DateTime dateTwo)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get top five pharmacy");
        var request = await (from pharmacy in ctx.Pharmacys
                             from productPharmacy in pharmacy.ProductPharmacys
                             from sale in productPharmacy.Product.Sales
                             where sale.PaymentDate < dateTwo && sale.PaymentDate > dateOne
                             orderby productPharmacy.Product.Sales.Count
                             select pharmacy.PharmacyName).Distinct().Take(5).ToListAsync();
        if (!request.Any())
        {
            _logger.LogInformation("Not found pharmacys with sales between {dateOne} and {dateTwo}", dateOne, dateTwo);
            return NotFound($"There are no sales between this time interval between {dateOne} and {dateTwo}");
        }
        else
        {
            _logger.LogInformation("Get information about top five pharmacy with sales between {dateOne} and {dateTwo}", dateOne, dateTwo);
            return Ok(request);
        }
    }
    /// <summary>
    ///Get pharmacy from address
    /// </summary>
    /// <param name="productId">Product Id</param> 
    /// <param name="address">Address pharmacy</param>
    /// <param name="countProduct">Count Product</param>
    /// <returns>Pharmacy from address</returns>
    [HttpGet("pharmacy-from-address")]
    public async Task<ActionResult<List<dynamic>>> GetPharmacyFromAddress(uint productId, string address, int countProduct)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get pharmacy from address");
        var request = await (from pharmacy in ctx.Pharmacys
                             from productPharmacy in pharmacy.ProductPharmacys
                             from sale in productPharmacy.Product.Sales
                             where productPharmacy.Product.Id == productId
                             && productPharmacy.ProductCount > countProduct
                             && pharmacy.PharmacyAddress.Contains(address)
                             orderby pharmacy.PharmacyName
                             select pharmacy.PharmacyName).Distinct().ToListAsync();
        if (!request.Any())
        {
            _logger.LogInformation("Not found pharmacys {productId}, {address}, {countProduct}", productId, address, countProduct);
            return NotFound($"There are no pharmacy with these parameters: {productId}, {address}, {countProduct}");
        }
        else
        {
            _logger.LogInformation("Get information about pharmacy from address: {productId}, {address} ,{countProduct}", productId, address, countProduct);
            return Ok(request);
        }
    }
    /// <summary>
    ///Get pharmacy with min cost
    /// </summary>
    /// <param name="productId">Product Id</param> 
    /// <returns>Pharmacy with min cost</returns>
    [HttpGet("pharmacy-min-cost")]
    public async Task<ActionResult<List<dynamic>>> GetPharmacyMinCost(uint productId)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get pharmacy min cost");
        var request = await (from pharmacy in ctx.Pharmacys
                             from productPharmacy in pharmacy.ProductPharmacys
                             where productPharmacy.Product.Id == productId
                             && productPharmacy.ProductCost == (from product in ctx.Products
                                                                from productPharmacy in product.ProductPharmacys
                                                                where productPharmacy.Product.Id == productId
                                                                select productPharmacy.ProductCost).Min()
                             select pharmacy.PharmacyName).ToListAsync();
        if (!request.Any())
        {
            _logger.LogInformation("Not found product {productId}", productId);
            return NotFound($"There are no pharmacy with product {productId}");
        }
        else
        {
            _logger.LogInformation("Get information about pharmacy with min cost: {productId}", productId);
            return Ok(request);
        }
    }
}