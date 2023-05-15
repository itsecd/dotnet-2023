using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMarket;
using MusicMarketplace;
using MusicMarketServer.Dto;

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
    /// Хранение DbContext
    /// </summary>
    private readonly IDbContextFactory<MusicMarketDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор контроллера product
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public ProductController(ILogger<ProductController> logger, IDbContextFactory<MusicMarketDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }


    /// <summary>
    /// GET-запрос на получение всех товаров коллекции
    /// </summary>
    /// <returns>list of products</returns>
    [HttpGet]
    public async Task<IEnumerable<ProductGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get products");
        var products = await context.Products.ToListAsync();
        return _mapper.Map<IEnumerable<ProductGetDto>>(products);
    }

    /// <summary>
    /// GET-запрос на получение элемента в соответствии с ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Product with input id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductGetDto>(product));
        }
    }

    /// <summary>
    /// POST-запрос на добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="product"></param>
    [HttpPost]
    public async void Post([FromBody] ProductPostDto product)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Products.AddAsync(_mapper.Map<Product>(product));
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// PUT-запрос на замену существующего элемента коллекции
    /// </summary>
    /// <param name="id"></param>
    /// <param name="productToPut"></param>
    /// <returns>Ok()</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductPostDto productToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product:{id}", id);
            return NotFound();
        }
        else
        {
            context.Update(_mapper.Map(productToPut, product));
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
        var product = await context.Products.FirstOrDefaultAsync(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product:{id}", id);
            return NotFound();
        }
        else
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
