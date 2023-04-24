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
    public IEnumerable<AuctionGetDto> Get()
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get information about all auctions");
        return _mapper.Map<IEnumerable<AuctionGetDto>>(context.Auctions);
    }

    /// <summary>
    /// Get an auction by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>AuctionGetDto</returns>
    [HttpGet("{id}")]
    public ActionResult<AuctionGetDto?> Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var auction = context.Auctions.FirstOrDefault(auction => auction.Id == id);
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
    /// <param name="auction"></param>
    [HttpPost]
    public void Post([FromBody] AuctionPostDto auction)
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post a new auction");
        context.Auctions.Add(_mapper.Map<Auction>(auction));
        context.SaveChanges();
    }

    /// <summary>
    /// Put an auction
    /// </summary>
    /// <param name="id"></param>
    /// <param name="auctionToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AuctionPostDto auctionToPut)
    {
        using var context = _contextFactory.CreateDbContext();
        var auction = context.Auctions.FirstOrDefault(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(auctionToPut, auction);
            context.SaveChanges();
            _logger.LogInformation("Put an auction");
            return Ok();
        }
    }

    /// <summary>
    /// Delete an auction by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var auction = context.Auctions.FirstOrDefault(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with {id}", id);
            return NotFound();
        }
        else
        {
            context.Auctions.Remove(auction);
            context.SaveChanges();
            _logger.LogInformation("Delete an auction");
            return Ok();
        }
    }
}
