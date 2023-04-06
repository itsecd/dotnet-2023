using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Server.Repository;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for shops
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ShopController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public ShopController(ILogger<ProductsController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
