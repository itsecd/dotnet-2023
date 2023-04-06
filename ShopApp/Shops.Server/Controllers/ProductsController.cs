using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Domain;
using Shops.Server.Dto;
using Shops.Server.Repository;

namespace Shops.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;

    public ProductsController(ILogger<ProductsController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public ActionResult<IEnumerable<ProductGetDto>> Get()
    {
        return Ok(_shopRepository.Products.Select(product => _mapper.Map<ProductGetDto>(product)));
    }

    [HttpGet("{id}")]
    public ActionResult<ProductGetDto> Get(int id)
    {

        var product = _shopRepository.Products.FirstOrDefault(product => product.ProductId == id);
        if (product == null) 
        {
            _logger.LogInformation($"Not found product with barcode = {id}");
            return NotFound();
        }
        else
        { 
            return Ok(_mapper.Map<ProductGetDto>(product));
        }
    }
    [HttpPost]
    public void Post([FromBody] ProductPostDto product)
    {
        _shopRepository.Products.Add(_mapper.Map<Product>(product));
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _shopRepository.Products.FirstOrDefault(product => product.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        else
        {
            _mapper.Map<ProductPostDto, Product>(productToPut, product);
            return Ok();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) 
    {
        var product = _shopRepository.Products.FirstOrDefault(product => product.ProductId == id);
        if(product == null)
        {
            return NotFound();
        }
        else
        {
            _shopRepository.Products.Remove(product);
            return Ok();
        }
    }
}
