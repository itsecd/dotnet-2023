using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket;
using MusicMarketServer.Dto;
using MusicMarketServer.Resository;

namespace MusicMarketServer.Controllers;

/// <summary>
/// Контроллер истории покупок
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PurchaseController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<PurchaseController> _logger;

    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IMusicMarketRepository _purchasesRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public PurchaseController(ILogger<PurchaseController> logger, IMusicMarketRepository purchasesRepository, IMapper mapper)
    {
        _logger = logger;
        _purchasesRepository = purchasesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <param name="id"></param>
    [HttpGet]
    public IEnumerable<PurchaseGetDto> Get()
    {
        _logger.LogInformation("Get list of purchase");
        return _purchasesRepository.Purchases.Select(purchase => _mapper.Map<PurchaseGetDto>(purchase));
    }

    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<PurchaseGetDto> Get(int id)
    {
        var purchaseById = _purchasesRepository.Purchases.FirstOrDefault(purchaseById => purchaseById.Id == id);
        if (purchaseById == null)
        {
            _logger.LogInformation($"Not found purchase with id =", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get product with id", id);
            return Ok(_mapper.Map<ProductGetDto>(purchaseById));
        }
    }

    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="purchase"></param>
    [HttpPost]
    public void Post([FromBody] PurchasePostDto purchase)
    {
        _logger.LogInformation($"Add new purchase");
        _purchasesRepository.Purchases.Add(_mapper.Map<Purchase>(purchase));
    }

    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="purchaseToPut"></param>
    /// <returns></returns> 
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PurchasePostDto purchaseToPut)
    {
        var purchase = _purchasesRepository.Purchases.FirstOrDefault(purchase => purchase.Id == id);
        if (purchase == null)
        {
            _logger.LogInformation($"Not found purchase with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Update information purchase with id = {id}");
            _mapper.Map<PurchasePostDto, Purchase>(purchaseToPut, purchase);
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
        var purchase = _purchasesRepository.Purchases.FirstOrDefault(purchase => purchase.Id == id);
        if (purchase == null)
        {
            _logger.LogInformation($"Not found purchase with id: {id}");
            return NotFound();
        }
        else
        {
            _purchasesRepository.Purchases.Remove(purchase);
            _logger.LogInformation("Delete purchase with id: {0}", id);
            return Ok();
        }
    }
}
