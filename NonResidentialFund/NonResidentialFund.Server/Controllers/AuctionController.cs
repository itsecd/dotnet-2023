using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly IDbContextFactory<NonResidentialFundContext> _contextFactory;
    private readonly ILogger<AuctionController> _logger;
    private readonly INonResidentialFundRepository _auctionsRepository;
    private readonly IMapper _mapper;

    public AuctionController(IDbContextFactory<NonResidentialFundContext> contextFactory, ILogger<AuctionController> logger, 
        INonResidentialFundRepository auctionsRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _auctionsRepository = auctionsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all auctions
    /// </summary>
    /// <returns>List of auctions</returns>
    [HttpGet]
    public async Task<IEnumerable<AuctionGetDto>> Get()
    {
        _logger.LogInformation("Get all auctions");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<AuctionGetDto>>(ctx.Auctions); ;
    }

    /// <summary>
    /// Returns the auction by the specified id
    /// </summary>
    /// <param name="id">id of the auction</param>
    /// <returns>Result of operation and auction object</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AuctionGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get auction with id: {id}", id);
            return Ok(_mapper.Map<AuctionGetDto>(auction));
        }
    }

    /// <summary>
    /// Creates new auction
    /// </summary>
    /// <param name="auction">Auction to be created</param>
    [HttpPost]
    public async void Post([FromBody] AuctionPostDto auction)
    {
        _logger.LogInformation("Post request auctions: create auction");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auctionToCreate = _mapper.Map<Auction>(auction);
        ctx.Auctions.Add(auctionToCreate);
        ctx.SaveChanges();
    }

    /// <summary>
    /// Changes the auction by the specified id
    /// </summary>
    /// <param name="id">Id of the auction to be changed</param>
    /// <param name="auctionToPut">New auction data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AuctionPostDto auctionToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Updated auction with id {id}", id);
            ctx.Auctions.Update(_mapper.Map(auctionToPut, auction));
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Removes the auction by the specified id
    /// </summary>
    /// <param name="id">Id of the auction to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Auctions.Remove(auction);
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Returns the registration numbers of the buildings that were offered at the specified auction
    /// </summary>
    /// <param name="id">Id of the auction</param>
    /// <returns>List of buildings that were offered at the specified auction</returns>
    [HttpGet("{id}/Buildings")]
    public async Task<ActionResult<IEnumerable<BuildingAuctionConnectionForAuctionDto>>> GetBuildings(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get building offered on auction with id: {id}", id);
            return Ok(_mapper.Map<IEnumerable<BuildingAuctionConnectionForAuctionDto>>(
                ctx.BuildingAuctionConnections.Where(connection => connection.AuctionId == id))
                );
        }
    }

    /// <summary>
    /// Adds a new building to the list of buildings for sale at the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Building to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{id}/Buildings")]
    public async Task<IActionResult> PostBuilding(int id, [FromBody] BuildingAuctionConnectionForAuctionDto connection)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        var building = ctx.Buildings.FirstOrDefault(building => building.RegistrationNumber == connection.BuildingId);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            if (building != null && ctx.BuildingAuctionConnections.FirstOrDefault(conn => conn.BuildingId == connection.BuildingId && conn.AuctionId == id) == null)
            {
                var connectionToAdd = new BuildingAuctionConnection(connection.BuildingId, id);
                ctx.BuildingAuctionConnections.Add(connectionToAdd);
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
    /// Removes a building from the list of buildings for sale at the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}/Buildings")]
    public async Task<IActionResult> DeleteBuilding(int id, [FromBody] BuildingAuctionConnectionForAuctionDto connection)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        var building = ctx.Buildings.FirstOrDefault(building => building.RegistrationNumber == connection.BuildingId);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            var connectionToDelete = ctx.BuildingAuctionConnections.FirstOrDefault(conn => conn.BuildingId == connection.BuildingId);
            if (connectionToDelete != null)
            {
                ctx.BuildingAuctionConnections.Remove(connectionToDelete);
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
    /// Returns the id of the buyers who participated in the specified auction
    /// </summary>
    /// <param name="id">Id of the auction</param>
    /// <returns>List of buyers who participated in the specified auction</returns>
    [HttpGet("{id}/Buyers")]
    public async Task<ActionResult<IEnumerable<BuyerAuctionConnectionForAuctionDto>>> GetBuyers(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get building offered on auction with id: {id}", id);
            return Ok(_mapper.Map<IEnumerable<BuyerAuctionConnectionForAuctionDto>>(
                ctx.BuyerAuctionConnections.Where(connection => connection.AuctionId == id))
                );
        }
    }

    /// <summary>
    /// Adds a new buyer to the list of buyers who participated in the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Buyer to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{id}/Buyers")]
    public async Task<IActionResult> PostBuilding(int id, [FromBody] BuyerAuctionConnectionForAuctionDto connection)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        var buyer = ctx.Buyers.FirstOrDefault(buyer => buyer.BuyerId == connection.BuyerId);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            if (buyer != null && ctx.BuyerAuctionConnections.FirstOrDefault(conn => conn.BuyerId == connection.BuyerId) == null)
            {
                var connectionToAdd = new BuyerAuctionConnection(connection.BuyerId, id);
                ctx.BuyerAuctionConnections.Add(connectionToAdd);
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
    /// Removes a buyer from the list of buyers who participated in the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Buyer to be remove</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}/Buyers")]
    public async Task<IActionResult> DeleteBuyer(int id, [FromBody] BuyerAuctionConnectionForAuctionDto connection)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        var buyer = ctx.Buyers.FirstOrDefault(buyer => buyer.BuyerId == connection.BuyerId);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            var connectionToDelete = ctx.BuyerAuctionConnections.FirstOrDefault(conn => conn.BuyerId == connection.BuyerId);
            if (connectionToDelete != null)
            {
                ctx.BuyerAuctionConnections.Remove(connectionToDelete);
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
