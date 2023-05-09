using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PonrfDomain;
using PonrfServer.Dto;

namespace PonrfServer.Controllers;

/// <summary>
/// Auction controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly ILogger<AuctionController> _logger;

    private readonly IDbContextFactory<PonrfContext> _contextFactory;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for AuctionController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public AuctionController(ILogger<AuctionController> logger, IDbContextFactory<PonrfContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about all auctions
    /// </summary>
    /// <returns>List of auctions</returns>
    [HttpGet]
    public async Task<IEnumerable<AuctionGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about all auctions");
        return _mapper.Map<IEnumerable<AuctionGetDto>>(context.Auctions);
    }

    /// <summary>
    /// Get an auction by id
    /// </summary>
    /// <param name="id">Auction's id</param>
    /// <returns>Auction with required id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<AuctionGetDto?>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var auction = await context.Auctions.FirstOrDefaultAsync(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get an auction");
            return Ok(_mapper.Map<AuctionGetDto>(auction));
        }
    }

    /// <summary>
    /// Post a new auction
    /// </summary>
    /// <param name="auction">New auction</param>
    /// <returns>Ok (success code)</returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] AuctionPostDto auction)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post a new auction");
        await context.Auctions.AddAsync(_mapper.Map<Auction>(auction));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put an auction
    /// </summary>
    /// <param name="id">Auction's id</param>
    /// <param name="auctionToPut">New auction</param>
    /// <returns>Ok (success code) or NotFound (error code)</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AuctionPostDto auctionToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var auction = await context.Auctions.FirstOrDefaultAsync(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(auctionToPut, auction);
            await context.SaveChangesAsync();
            _logger.LogInformation("Put an auction");
            return Ok();
        }
    }

    /// <summary>
    /// Delete an auction by id
    /// </summary>
    /// <param name="id">Auction's id</param>
    /// <returns>Ok (success code) or NotFound (error code)</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var auction = await context.Auctions.FirstOrDefaultAsync(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with {id}", id);
            return NotFound();
        }
        else
        {
            context.Auctions.Remove(auction);
            await context.SaveChangesAsync();
            _logger.LogInformation("Delete an auction");
            return Ok();
        }
    }
}
