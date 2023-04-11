using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket;
using MusicMarketServer.Dto;
using MusicMarketServer.Repository;

namespace MusicMarketServer.Controllers;

/// <summary>
/// Контроллер продавцов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SellerController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<SellerController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IMusicMarketRepository _sellersRepository;

    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public SellerController(ILogger<SellerController> logger, IMusicMarketRepository sellersRepository, IMapper mapper)
    {
        _logger = logger;
        _sellersRepository = sellersRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<SellerGetDto> Get()
    {
        _logger.LogInformation("Get list of sellers");
        return _sellersRepository.Sellers.Select(seller => _mapper.Map<SellerGetDto>(seller));
    }


    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<SellerGetDto> Get(int id)
    {
        var sellerById = _sellersRepository.Sellers.FirstOrDefault(seller => seller.Id == id);
        if (sellerById == null)
        {
            _logger.LogInformation($"Not found specialty with id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get specialty with id {0}", id);
            return Ok(_mapper.Map<SellerGetDto>(sellerById));
        }
    }


    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="seller"></param>
    [HttpPost]
    public void Post([FromBody] SellerPostDto seller)
    {
        _logger.LogInformation($"Add new seller");
        _sellersRepository.Sellers.Add(_mapper.Map<Seller>(seller));
    }

    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sellerToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SellerPostDto sellerToPut)
    {
        var seller = _sellersRepository.Sellers.FirstOrDefault(seller => seller.Id == id);
        if (seller == null)
        {
            _logger.LogInformation($"Not found seller with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information seller with id = {id}");
            _mapper.Map<SellerPostDto, Seller>(sellerToPut, seller);
            return Ok();
        }
    }

    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var seller = _sellersRepository.Sellers.FirstOrDefault(seller => seller.Id == id);
        if (seller == null)
        {
            _logger.LogInformation($"Not found seller with id: {id}");
            return NotFound();
        }
        else
        {
            _sellersRepository.Sellers.Remove(seller);
            _logger.LogInformation("Delete seller with id: {0}", id);
            return Ok();
        }
    }
}

