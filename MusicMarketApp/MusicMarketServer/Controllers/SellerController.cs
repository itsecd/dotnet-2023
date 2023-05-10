using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket;
using MusicMarketServer.Dto;
using Microsoft.EntityFrameworkCore;
using MusicMarketplace;

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
    /// Хранение DbContext
    /// </summary>
    private readonly IDbContextFactory<MusicMarketDbContext> _contextFactory;

    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера seller
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public SellerController(ILogger<SellerController> logger, IDbContextFactory<MusicMarketDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// GET-запрос на получение всех элементов коллекции
    /// </summary>
    /// <returns>list of sellers</returns>
    [HttpGet]
    public async Task<IEnumerable<SellerGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get sellers");
        var sellers = await context.Sellers.ToListAsync();
        return _mapper.Map<IEnumerable<SellerGetDto>>(sellers);
    }


    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>seller by id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<SellerGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var seller = await context.Sellers.FirstOrDefaultAsync(seller => seller.Id == id);
        if (seller == null)
        {
            _logger.LogInformation("Not found seller:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<SellerGetDto>(seller));
        }
    }


    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="seller"></param>
    [HttpPost]
    public async void Post([FromBody] SellerPostDto seller)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Sellers.AddAsync(_mapper.Map<Seller>(seller));
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sellerToPut"></param>
    /// <returns>Ok()</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SellerPostDto sellerToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var seller = await context.Sellers.FirstOrDefaultAsync(seller => seller.Id == id);
        if (seller == null)
        {
            _logger.LogInformation("Not found seller:{id}", id);
            return NotFound();
        }
        else
        {
            context.Update(_mapper.Map(sellerToPut, seller));
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// DELETE-запрос на удаление элемента из коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Ok()</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var seller = await context.Sellers.FirstOrDefaultAsync(seller => seller.Id == id);
        if (seller == null)
        {
            _logger.LogInformation("Not found seller:{id}", id);
            return NotFound();
        }
        else
        {
            context.Sellers.Remove(seller);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

