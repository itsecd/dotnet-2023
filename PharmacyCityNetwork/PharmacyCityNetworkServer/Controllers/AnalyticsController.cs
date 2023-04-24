using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
/// <summary>
/// Analytics controller for queries
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }
    /// <summary>
    ///Get all products from pharmacy 
    /// </summary>
    /// <param name="pharmacyId"></param>
    /// <returns></returns>
    [HttpGet("all-products-from-pharmacy")]
    public ActionResult<IEnumerable<ProductGetDto>> GetAllProductFromPharmacy(uint pharmacyId)
    {
        _logger.LogInformation("Get all product from pharmacy");
        var request = (from pharmacy in _pharmacyCityNetworkRepository.Pharmacys
                       from productPharmacy in pharmacy.ProductPharmacys
                       where pharmacy.Id == pharmacyId
                       orderby productPharmacy.Product.ProductName
                       select _mapper.Map<ProductGetDto>(productPharmacy.Product));
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
    /// <param name="productId"></param>
    /// <returns></returns>
    [HttpGet("products-from-pharmacy")]
    public ActionResult<List<dynamic>> GetProductsFromPharmacy(uint productId)
    {
        _logger.LogInformation("Get products from pharmacy");
        var request = (from pharmacy in _pharmacyCityNetworkRepository.Pharmacys
                       from productPharmacy in pharmacy.ProductPharmacys
                       where productPharmacy.Product.Id == productId
                       group productPharmacy by productPharmacy.Pharmacy.PharmacyName into g
                       select new
                       {
                            Pharmacy = g.Key,
                            Count = (from pharmacy in _pharmacyCityNetworkRepository.Pharmacys
                                     from productPharmacy in pharmacy.ProductPharmacys
                                     where productPharmacy.Pharmacy.PharmacyName.Equals(g.Key)
                                     where productPharmacy.Product.Id == productId 
                                     select productPharmacy.ProductCount)
                       }).ToList();
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
    /// <returns></returns>
    [HttpGet("farm-group")]
    public ActionResult<List<dynamic>> GetFarmGroup()
    {
        _logger.LogInformation("Get average cost for each farmGroup and pharmacy");
        var request = (from pharmaGroup in _pharmacyCityNetworkRepository.PharmaGroups
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
               ).ToList();
        _logger.LogInformation("Get information about average cost for each farmGroup and pharmacy");
        return Ok(request);
    }
    /// <summary>
    ///Get top five pharmacy
    /// </summary>
    /// <param name="dateOne"></param> 
    /// <param name="dateTwo"></param>
    /// <returns></returns>
    [HttpGet("top-five-pharmacy")]
    public ActionResult<List<dynamic>> GetTopFivePharmacy(DateTime dateOne, DateTime dateTwo)
    {
        _logger.LogInformation("Get top five pharmacy");
        var request = (from pharmacy in _pharmacyCityNetworkRepository.Pharmacys
                       from productPharmacy in pharmacy.ProductPharmacys
                       from sale in productPharmacy.Product.Sales
                       where sale.PaymentDate < dateTwo && sale.PaymentDate > dateOne
                       orderby productPharmacy.Product.Sales.Count
                       select pharmacy.PharmacyName).Distinct().Take(5).ToList();
        if (!request.Any())
        {
            _logger.LogInformation("Not found pharmacys with sales between {dateOne} and {dateTwo}", dateOne, dateTwo);
            return NotFound("There are no sales between this time interval");
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
    /// <param name="productId"></param> 
    /// <param name="address"></param>
    /// <param name="countProduct"></param>
    /// <returns></returns>
    [HttpGet("pharmacy-from-address")]
    public ActionResult<List<dynamic>> GetPharmacyFromAddress(uint productId, string address, int countProduct)
    {
        _logger.LogInformation("Get pharmacy from address");
        var request = (from pharmacy in _pharmacyCityNetworkRepository.Pharmacys
                       from productPharmacy in pharmacy.ProductPharmacys
                       from sale in productPharmacy.Product.Sales
                       where productPharmacy.Product.Id == productId
                       && productPharmacy.ProductCount > countProduct
                       && pharmacy.PharmacyAddress.Contains(address)
                       orderby pharmacy.PharmacyName
                       select pharmacy.PharmacyName).Distinct().ToList();
        if (!request.Any())
        {
            _logger.LogInformation("Not found pharmacys {productId}, {address}, {countProduct}", productId, address, countProduct);
            return NotFound($"There are no pharmacy with these parameters");
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
    /// <param name="productId"></param> 
    /// <returns></returns>
    [HttpGet("pharmacy-min-cost")]
    public ActionResult<List<dynamic>> GetPharmacyMinCost(uint productId)
    {
        _logger.LogInformation("Get pharmacy min cost");
        var minCost = (from product in _pharmacyCityNetworkRepository.Products
                       from productPharmacy in product.ProductPharmacys
                       where productPharmacy.Product.Id == productId
                       select productPharmacy.ProductCost).Min();
        var request = (from pharmacy in _pharmacyCityNetworkRepository.Pharmacys
                       from productPharmacy in pharmacy.ProductPharmacys
                       where productPharmacy.Product.Id == productId
                       && productPharmacy.ProductCost == minCost
                       select pharmacy.PharmacyName).ToList();
        if (!request.Any())
        {
            _logger.LogInformation("Not found product {productId}", productId);
            return NotFound($"There are no pharmacy with product");
        }
        else
        {
            _logger.LogInformation("Get information about pharmacy with min cost: {productId}", productId);
            return Ok(request);
        }
    }
}