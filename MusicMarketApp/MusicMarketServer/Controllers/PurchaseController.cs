using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMarket;
using MusicMarketplace;
using MusicMarketServer.Dto;
using Ubiety.Dns.Core.Records.NotUsed;

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
    /// Хранение DbContext
    /// </summary>
    private readonly IDbContextFactory<MusicMarketDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера purchase
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public PurchaseController(ILogger<PurchaseController> logger, IDbContextFactory<MusicMarketDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns>Returns a list of purchases</returns>
    [HttpGet]
    public async Task<IEnumerable<PurchaseGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get purchases");
        var purchases = await context.Purchases.ToListAsync();
        return _mapper.Map<IEnumerable<PurchaseGetDto>>(purchases);
    }

    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id">PurchaseId</param>
    /// <returns>Ok(found purchase with input id)</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PurchaseGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var purchase = await context.Purchases.FirstOrDefaultAsync(purchase => purchase.Id == id);
        if (purchase == null)
        {
            _logger.LogInformation("Not found purchase:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<PurchaseGetDto>(purchase));
        }
    }

    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="purchase"> New purchase</param>
    [HttpPost]
    public async Task<ActionResult<PurchaseGetDto>> Post([FromBody] PurchasePostDto purchase)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var newPurchase = _mapper.Map<Purchase>(purchase);
        await context.Purchases.AddAsync(newPurchase);
        await context.SaveChangesAsync();
        return Ok(_mapper.Map<PurchaseGetDto>(newPurchase));
    }

    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id">PurchaseId</param>
    /// <param name="purchaseToPut">New purchase</param>
    /// <returns>Update purchase by id</returns> 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PurchasePostDto purchaseToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var purchase = await context.Purchases.FirstOrDefaultAsync(purchase => purchase.Id == id);
        if (purchase == null)
        {
            _logger.LogInformation("Not found purchase:{id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(purchaseToPut, purchase);
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id">PurchaseId</param>
    /// <returns>Delete purchase by id</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var purchase = await context.Purchases.FirstOrDefaultAsync(purchase => purchase.Id == id);
        if (purchase == null)
        {
            _logger.LogInformation("Not found purchase:{id}", id);
            return NotFound();
        }
        else
        {
            context.Purchases.Remove(purchase);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
