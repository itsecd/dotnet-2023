using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Domain;
using Shops.Server.Dto;
using Shops.Server.Repository;

namespace Shops.Server.Controllers;
/// <summary>
/// Controller for shops
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ShopController : ControllerBase
{
    private readonly ILogger<ShopController> _logger;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public ShopController(ILogger<ShopController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of shop
    /// </summary>
    /// <returns>Ok(list of shop)</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ShopGetDto>> Get()
    {
        _logger.LogInformation($"Get list of shop");
        return Ok(_shopRepository.Shops.Select(shop => _mapper.Map<ShopGetDto>(shop)));
    }
    /// <summary>
    /// Return shop by id
    /// </summary>
    /// <param name="id"> Shop id</param>
    /// <returns>Shop</returns>
    [HttpGet("{id}")]
    public ActionResult<ShopGetDto> Get(int id)
    {
        var shop = _shopRepository.Shops.FirstOrDefault(shop => shop.Id == id);
        if (shop == null)
        {
            _logger.LogInformation($"Not found shop with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Shop with id = {id}");
            return Ok(_mapper.Map<ShopGetDto>(shop));
        }
    }
    /// <summary>
    /// Add new shop in list of shops
    /// </summary>
    /// <param name="shop"> New shop</param>
    /// <returns>Ok(add new shop) </returns>
    [HttpPost]
    public IActionResult Post([FromBody] ShopPostDto shop)
    {
        var newId = _shopRepository.Shops
           .Select(shop => shop.Id)
           .DefaultIfEmpty()
           .Max() + 1;
        var newShop = _mapper.Map<Shop>(shop);
        newShop.Id = newId;
        _shopRepository.Shops.Add(newShop);
        _logger.LogInformation($"Post shop, id = {newId}");
        return Ok();
    }
    /// <summary>
    /// Updates shop information
    /// </summary>
    /// <param name="id">Shop id</param>
    /// <param name="shopToPut">New information</param>
    /// <returns>Ok (update shop by id) or NotFound</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ShopPostDto shopToPut)
    {
        var shop = _shopRepository.Shops.FirstOrDefault(shop => shop.Id == id);
        if (shop == null)
        {
            _logger.LogInformation($"Not found shop with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information shop with id = {id}");
            _mapper.Map<ShopPostDto, Shop>(shopToPut, shop);
            return Ok();
        }
    }
    /// <summary>
    /// Delete shop by id
    /// </summary>
    /// <param name="id">Shop id</param>
    /// <returns>Ok (delete shop by id) or NotFound</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var shop = _shopRepository.Shops.FirstOrDefault(shop => shop.Id == id);
        if (shop == null)
        {
            _logger.LogInformation($"Not found shop with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete shop with id = {id}");
            _shopRepository.Shops.Remove(shop);
            return Ok();
        }
    }
}
