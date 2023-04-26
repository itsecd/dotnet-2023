using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Domain;
using StoreApp.Server.Dto;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly IDbContextFactory<StoreAppContext> _contextFactory;
    private readonly ILogger<SaleController> _logger;
    private readonly IMapper _mapper;

    public SaleController(IDbContextFactory<StoreAppContext> contextFactory, ILogger<SaleController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// GET all Sales
    /// </summary>
    /// <returns>
    /// JSON Sales
    /// </returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<SaleGetDto>> Get()
    {
        _logger.LogInformation("GET sales");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var sales = await ctx.Sales.ToArrayAsync();
        return _mapper.Map<IEnumerable<SaleGetDto>>(sales);
    }

    /// <summary>
    /// GET Sale by ID
    /// </summary>
    /// <param name="saleId">
    /// ID
    /// </param>
    /// <returns>
    /// JSON Sale
    /// </returns>
    [HttpGet("{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SaleGetDto>> Get(int saleId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getSale = await ctx.Sales.FirstOrDefaultAsync(sale => sale.SaleId == saleId);
        if (getSale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET sale with ID: {saleId}.");
            return Ok(_mapper.Map<SaleGetDto>(getSale));
        }

    }

    /// <summary>
    /// POST sale
    /// </summary>
    /// <param name="saleToPost">
    /// Sale
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] SalePostDto saleToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Sales.AddAsync(_mapper.Map<Sale>(saleToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST sale ({saleToPost.DateSale}, {saleToPost.CustomerId}, {saleToPost.StoreId}, {saleToPost.Sum})");
        return Ok();
    }

    /// <summary>
    /// PUT sale
    /// </summary>
    /// <param name="saleId">
    /// ID
    /// </param>
    /// <param name="saleToPut">
    /// Sale
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int saleId, [FromBody] SalePostDto saleToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var sale = await ctx.Sales.FirstOrDefaultAsync(x => x.SaleId == saleId);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT sale with id {saleId} ({saleToPut.DateSale}->{saleToPut.DateSale}, {saleToPut.CustomerId}->{saleToPut.CustomerId}, " +
                $"{saleToPut.StoreId}->{saleToPut.StoreId}, {saleToPut.Sum}->{saleToPut.Sum})");
            _mapper.Map(saleToPut, sale);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// DELETE sale
    /// </summary>
    /// <param name="saleId">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int saleId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var sale = await ctx.Sales.FirstOrDefaultAsync(x => x.SaleId == saleId);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE sale with ID: {saleId}");
            ctx.Sales.Remove(sale);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
