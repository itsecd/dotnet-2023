using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Domain;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductStoreController : ControllerBase
{

    private readonly ILogger<ProductStoreController> _logger;
    private readonly IStoreAppRepository _storeAppRepository;
    private readonly IMapper _mapper;

    public ProductStoreController(ILogger<ProductStoreController> logger, IStoreAppRepository storeAppRepository, IMapper mapper)
    {
        _logger = logger;
        _storeAppRepository = storeAppRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// GET all ProductStore
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ProductStoreGetDto> Get()
    {
        _logger.LogInformation("GET productStores");
        return _storeAppRepository.ProductStores.Select(productStore => _mapper.Map<ProductStoreGetDto>(productStore));
    }

    /// <summary>
    /// GET by ID
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <returns>
    /// JSON ProductStore
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<ProductStoreGetDto> Get(int id)
    {
        var getProductStore = _storeAppRepository.ProductStores.FirstOrDefault(productStore => productStore.Id == id);
        if (getProductStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productStore with ID: {id}.");
            return Ok(_mapper.Map<ProductStoreGetDto>(getProductStore));
        }

    }


    /// <summary>
    /// GET product in all stores by ID product
    /// </summary>
    /// <param name="productId">
    /// ID product
    /// </param>
    /// <returns>
    /// JSON ProductStore
    /// </returns>
    [HttpGet("{productId}")]
    public ActionResult<ProductStoreGetDto> GetByProduct(int productId)
    {
        var getProductStore = _storeAppRepository.ProductStores.FirstOrDefault(productStore => productStore.ProductId == productId);
        if (getProductStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {productId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productStore with ID: {productId}.");
            return Ok(_mapper.Map<ProductStoreGetDto>(getProductStore));
        }

    }

    /// <summary>
    /// GET all products in by ID store
    /// </summary>
    /// <param name="storeId">
    /// ID store
    /// </param>
    /// <returns>
    /// JSON ProductStore
    /// </returns>
    [HttpGet("{storeId}")]
    public ActionResult<ProductStoreGetDto> GetByStore(int storeId)
    {
        var getProductStore = _storeAppRepository.ProductStores.FirstOrDefault(productStore => productStore.StoreId == storeId);
        if (getProductStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {storeId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET productStore with ID: {storeId}.");
            return Ok(_mapper.Map<ProductStoreGetDto>(getProductStore));
        }

    }

    /// <summary>
    /// POST ProductStore
    /// </summary>
    /// <param name="productStoreToPost">
    /// ProductStore
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    public ActionResult Post([FromBody] ProductStorePostDto productStoreToPost)
    {
        _storeAppRepository.ProductStores.Add(_mapper.Map<ProductStore>(productStoreToPost));
        _logger.LogInformation($"POST productStore ({productStoreToPost.ProductId}, {productStoreToPost.StoreId}, {productStoreToPost.Quantity})");
        return Ok();
    }

    /// <summary>
    /// PUT ProductStore
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <param name="productStoreToPut">
    /// ProductStore
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] ProductStorePostDto productStoreToPut)
    {
        var productStore = _storeAppRepository.ProductStores.FirstOrDefault(x => x.Id == id);
        if (productStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT productStore with ID: {id} ({productStore.ProductId}->{productStoreToPut.ProductId}, {productStore.StoreId}->{productStoreToPut.StoreId}, {productStore.Quantity}->{productStoreToPut.Quantity})");
            _mapper.Map(productStoreToPut, productStore);
            return Ok();
        }
    }

    /// <summary>
    /// DELETE ProductStore
    /// </summary>
    /// <param name="id">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var productStore = _storeAppRepository.ProductStores.FirstOrDefault(x => x.Id == id);
        if (productStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE productStore with ID: {id}");
            _storeAppRepository.ProductStores.Remove(productStore);
            return Ok();
        }
    }
}
