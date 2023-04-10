using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : Controller
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IStoreAppRepository _storeAppRepository;
    private readonly IMapper _mapper;

    public AnalyticsController(ILogger<AnalyticsController> logger, IStoreAppRepository storeAppRepository, IMapper mapper)
    {
        _logger = logger;
        _storeAppRepository = storeAppRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Display information about all products in a given store
    /// </summary>
    /// <param name="storeId">
    /// Id store
    /// </param>
    /// <returns>
    /// JSON products
    /// </returns>
    [HttpGet("/ProductsInSpecifiedStore/{storeId}")]
    public IActionResult ProductsInSpecifiedStore(int storeId)
    {
        var getStore = _storeAppRepository.Stores.FirstOrDefault(store => store.StoreId == storeId);
        if (getStore == null)
        {
            _logger.LogInformation($"Not found store with ID: {storeId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get information about products in store with ID: {storeId}");
            var result = from ps in _storeAppRepository.ProductStores
                         join p in _storeAppRepository.Products on ps.ProductId equals p.ProductId
                         join s in _storeAppRepository.Stores on ps.StoreId equals s.StoreId
                         where s.StoreId == storeId && ps.Quantity > 0
                         select _mapper.Map<ProductGetDto>(p);

            return Ok(result);
        }

    }


    /// <summary>
    /// For a given product, display a list of stores where it is located in availability
    /// </summary>
    /// <param name="productId">
    /// Id product
    /// </param>
    /// <returns>
    /// JSON stores
    /// </returns>
    [HttpGet("/StoresWithProduct/{productId}")]
    public IActionResult StoresWithProduct(int productId)
    {
        var getProduct = _storeAppRepository.Products.FirstOrDefault(product => product.ProductId == productId);
        if (getProduct == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get list of stores where product with ID {productId} is located in availability");
            var result = from ps in _storeAppRepository.ProductStores
                         join p in _storeAppRepository.Products on ps.ProductId equals p.ProductId
                         join s in _storeAppRepository.Stores on ps.StoreId equals s.StoreId
                         where ps.Quantity > 0 && p.ProductId == productId
                         select _mapper.Map<StoreGetDto>(s);

            return Ok(result);
        }
    }


    /// <summary>
    /// Display information about the average cost of goods of each product group for each store.
    /// </summary>
    /// <returns>
    /// JSON (Store, Avg, Category)
    /// </returns>
    [HttpGet("/InfomationAboutAvgPrice")]
    public IActionResult InfomationAboutAvgPrice()
    {
        _logger.LogInformation("Get information about the average cost of goods of each product group for each store.");
        var result = from ps in _storeAppRepository.ProductStores
                     join p in _storeAppRepository.Products on ps.ProductId equals p.ProductId
                     join s in _storeAppRepository.Stores on ps.StoreId equals s.StoreId
                     group new { p, s } by new { p.ProductGroup, s.StoreId } into grp
                     select new
                     {
                         StoreId = grp.Key.StoreId,
                         ProductCategory = grp.Key.ProductGroup,
                         AveragePrice = grp.Average(x => x.p.ProductPrice)
                     };

        return Ok(result);
    }


    /// <summary>
    /// Display the top 5 purchases by total sale amount.
    /// </summary>
    /// <returns>
    /// JSON sales
    /// </returns>
    [HttpGet("/TopSales")]
    public IActionResult TopSales()
    {
        _logger.LogInformation("Get top 5 purchases by total sale amount.");
        var result = ((from sa in _storeAppRepository.Sales
                       orderby sa.Sum descending
                       select sa).Take(5)).ToList();
        return Ok(result);
    }


    /// <summary>
    /// Display all information about products that exceed the storage date limit, indicating the store
    /// </summary>
    /// <returns>
    /// JSON store-product
    /// </returns>
    [HttpGet("/ExpiredProducts")]
    public IActionResult ExpiredProducts()
    {
        _logger.LogInformation("Display all information about products that exceed the storage date limit, indicating the store");
        var result = from ps in _storeAppRepository.ProductStores
                     join p in _storeAppRepository.Products on ps.ProductId equals p.ProductId
                     join s in _storeAppRepository.Stores on ps.StoreId equals s.StoreId
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
                     };
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
    public IActionResult StoresWithAmountMoreThen(double minSalesAmount)
    {
        if (minSalesAmount.GetType() != typeof(double))
        {
            return BadRequest("Invalid minSalesAmount parameter");
        }
        else
        {
            _logger.LogInformation($"Display a list of stores that sold goods for the month amount more then {minSalesAmount}");
            DateTime startDate = DateTime.Now.AddMonths(-2);
            var result = from sale in _storeAppRepository.Sales
                         where sale.DateSale >= startDate
                         group sale by sale.StoreId into storeGroup
                         select new
                         {
                             StoreId = storeGroup.Key,
                             TotalSales = storeGroup.Sum(sale => sale.Sum),
                         } into storeSales
                         where storeSales.TotalSales >= minSalesAmount
                         select new { StoreId = storeSales.StoreId, TotalSales = storeSales.TotalSales };
            return Ok(result);
        }
    }
}
