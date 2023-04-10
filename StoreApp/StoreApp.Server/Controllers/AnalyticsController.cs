using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Domain;
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
    
    [HttpGet("{storeId}")]
    public IEnumerable<ProductGetDto> ProductsInSpecifiedStore(int storeId)
    {
        _logger.LogInformation($"Get information about products in store with ID: {storeId}");
        var result = from ps in _storeAppRepository.ProductStores
                     join p in _storeAppRepository.Products on ps.ProductId equals p.ProductId
                     join s in _storeAppRepository.Stores on ps.StoreId equals s.StoreId
                     where s.StoreId == storeId && ps.Quantity > 0
                     select _mapper.Map<ProductGetDto>(p);

        return result;
    }
    
    [HttpGet("{productId}")]
    public IEnumerable<StoreGetDto> StoresWithProduct(int productId)
    {
        _logger.LogInformation($"Get stores with product ID: {productId}");
        var result = from ps in _storeAppRepository.ProductStores
                     join p in _storeAppRepository.Products on ps.ProductId equals p.ProductId
                     join s in _storeAppRepository.Stores on ps.StoreId equals s.StoreId
                     where ps.Quantity > 0 && p.ProductId == productId
                     select _mapper.Map<StoreGetDto>(s);

        return result;
    }
}
