using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Model;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BuyerController : ControllerBase
{
    private readonly IDbContextFactory<NonResidentialFundContext> _contextFactory;
    private readonly ILogger<BuyerController> _logger;
    private readonly IMapper _mapper;

    public BuyerController(IDbContextFactory<NonResidentialFundContext> contextFactory, ILogger<BuyerController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all buyers
    /// </summary>
    /// <returns>List of buyers</returns>
    [HttpGet]
    public async Task<IEnumerable<BuyerGetDto>> Get()
    {
        _logger.LogInformation("Get all buyers");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<BuyerGetDto>>(ctx.Buyers);
    }

    /// <summary>
    /// Returns the buyer by the specified id
    /// </summary>
    /// <param name="id">id of the buyer</param>
    /// <returns>Result of operation and buyer object</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BuyerGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var buyer = ctx.Buyers.FirstOrDefault(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get buyer with id: {id}", id);
            return Ok(_mapper.Map<BuyerGetDto>(buyer));
        }
    }

    /// <summary>
    /// Creates new buyer
    /// </summary>
    /// <param name="buyer">Buyer to be created</param>
    [HttpPost]
    public async void Post([FromBody] BuyerPostDto buyer)
    {
        _logger.LogInformation("Created new buyer");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Buyers.Add(_mapper.Map<Buyer>(buyer));
        ctx.SaveChanges();
    }

    /// <summary>
    /// Changes the buyer by the specified id
    /// </summary>
    /// <param name="id">Id of the buyer to be changed</param>
    /// <param name="buyerToPut">New buyer data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BuyerPostDto buyerToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var buyer = ctx.Buyers.FirstOrDefault(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Buyers.Update(_mapper.Map(buyerToPut, buyer));
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Removes the buyer by the specified id
    /// </summary>
    /// <param name="id">Id of the buyer to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var buyer = ctx.Buyers.FirstOrDefault(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Buyers.Remove(buyer);
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Returns auctions in which the specified buyer participated
    /// </summary>
    /// <param name="id">Id of the buyer</param>
    /// <returns>List of auctions, in which the specified buyer participated</returns>
    [HttpGet("{id}/Auctions")]
    public async Task<ActionResult<IEnumerable<BuyerAuctionConnectionForBuyerDto>>> GetAuctions(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var buyer = ctx.Buyers.Include(buyer => buyer.Auctions).FirstOrDefault(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get auctions in which the buyer with id {id} participated", id);
            return Ok(_mapper.Map<IEnumerable<BuyerAuctionConnectionForBuyerDto>>(buyer.Auctions));
        }
    }

    /// <summary>
    /// Adds a new auction to the list of auctions in which the specified buyer participated
    /// </summary>
    /// <param name="id">Id of the buyer</param>
    /// <param name="connection">Auction to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{id}/Auctions")]
    public async Task<IActionResult> PostAuction(int id, [FromBody] BuyerAuctionConnectionForBuyerDto connection)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var buyer = ctx.Buyers.Include(buyer => buyer.Auctions).FirstOrDefault(buyer => buyer.BuyerId == id);
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            if (auction != null && buyer.Auctions.FirstOrDefault(conn => conn.AuctionId == connection.AuctionId) == null)
            {
                var connectionToAdd = new BuyerAuctionConnection(id, connection.AuctionId);
                buyer.Auctions.Add(connectionToAdd);
                ctx.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }

    /// <summary>
    /// Removes a auction from the list of auctions in which the specified buyer participated
    /// </summary>
    /// <param name="id">Id of the buyer</param>
    /// <param name="connection">Auction to be remove</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}/Auctions")]
    public async Task<IActionResult> DeleteAuction(int id, [FromBody] BuyerAuctionConnectionForBuyerDto connection)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var buyer = ctx.Buyers.Include(buyer => buyer.Auctions).FirstOrDefault(buyer => buyer.BuyerId == id);
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            var connectionToDelete = buyer.Auctions.FirstOrDefault(conn => conn.AuctionId == connection.AuctionId);
            if (connectionToDelete != null)
            {
                buyer.Auctions.Remove(connectionToDelete);
                ctx.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
