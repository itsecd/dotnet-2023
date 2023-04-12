using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket;
using MusicMarketServer.Dto;
using MusicMarketServer.Repository;

namespace MusicMarketServer.Controllers;

/// <summary>
/// Контроллер товаров
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<ProductController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IMusicMarketRepository _productsRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public ProductController(ILogger<ProductController> logger, IMusicMarketRepository productsRepository, IMapper mapper)
    {
        _logger = logger;
        _productsRepository = productsRepository;
        _mapper = mapper;
    }


    /// <summary>
    /// GET-запрос на получение всех товаров коллекции
    /// </summary>
    /// <returns>list of products</returns>
    [HttpGet]
    public IEnumerable<ProductGetDto> Get()
    {
        _logger.LogInformation("Get list of products");
        return _productsRepository.Products.Select(product => _mapper.Map<ProductGetDto>(product));
    }

    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product with input id</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductGetDto> Get(int id)
    {
        var productById = _productsRepository.Products.FirstOrDefault(product => product.Id == id);
        if (productById == null)
        {
            _logger.LogInformation($"Not found product with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get product with id: {id}");
            return Ok(_mapper.Map<ProductGetDto>(productById));
        }
    }

    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="product"></param>
    [HttpPost]
    public void Post([FromBody] ProductPostDto product)
    {
        _logger.LogInformation("Add new product");
        _productsRepository.Products.Add(_mapper.Map<Product>(product));
    }

    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="productToPut"></param>
    /// <returns>Ok()</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _productsRepository.Customers.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information product with id = {id}");
            _mapper.Map<ProductPostDto, Customer>(productToPut, product);
            return Ok();
        }
    }

    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Ok()</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _productsRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with id: {id}");
            return NotFound();
        }
        else
        {
            _productsRepository.Products.Remove(product);
            _logger.LogInformation($"Delete product with id: : {id}");
            return Ok();
        }
    }
}
