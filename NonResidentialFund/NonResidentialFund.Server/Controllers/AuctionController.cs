using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly ILogger<AuctionController> _logger;

    private readonly INonResidentialFundRepository _auctionsRepository;

    private readonly IMapper _mapper;

    public AuctionController(ILogger<AuctionController> logger, INonResidentialFundRepository auctionsRepository, IMapper mapper)
    {
        _logger = logger;
        _auctionsRepository = auctionsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all auctions
    /// </summary>
    /// <returns>List of auctions</returns>
    [HttpGet]
    public IEnumerable<AuctionGetDto> Get()
    {
        _logger.LogInformation("Get all auctions");
        return _mapper.Map<IEnumerable<AuctionGetDto>>(_auctionsRepository.Auctions);
    }

    /// <summary>
    /// Returns the auction by the specified id
    /// </summary>
    /// <param name="id">id of the auction</param>
    /// <returns>Result of operation and auction object</returns>
    [HttpGet("{id:int}")]
    public ActionResult<AuctionGetDto> Get(int id)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
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
    public void Post([FromBody] AuctionPostDto auction)
    {
        _auctionsRepository.Auctions.Add(_mapper.Map<Auction>(auction));
    }

    /// <summary>
    /// Changes the auction by the specified id
    /// </summary>
    /// <param name="id">Id of the auction to be changed</param>
    /// <param name="auctionToPut">New auction data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AuctionPostDto auctionToPut)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(auctionToPut, auction);
            return Ok();
        }
    }

    /// <summary>
    /// Removes the auction by the specified id
    /// </summary>
    /// <param name="id">Id of the auction to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _auctionsRepository.Auctions.Remove(auction);
            return Ok();
        }
    }

    /// <summary>
    /// Returns the registration numbers of the buildings that were offered at the specified auction
    /// </summary>
    /// <param name="id">Id of the auction</param>
    /// <returns>List of buildings that were offered at the specified auction</returns>
    [HttpGet("buildings/{id}")]
    public ActionResult<IEnumerable<BuildingAuctionConnectionForAuctionDto>> GetBuildings(int id)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get building offered on auction with id: {id}", id);
            return Ok(_mapper.Map<IEnumerable<BuildingAuctionConnectionForAuctionDto>>(auction.Buildings));
        }
    }

    /// <summary>
    /// Adds a new building to the list of buildings for sale at the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Building to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("buildings/{id}")]
    public IActionResult PostBuilding(int id, [FromBody] BuildingAuctionConnectionForAuctionDto connection)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        var building = _auctionsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == connection.BuildingId);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            if (building != null && auction.Buildings.FirstOrDefault(conn => conn.BuildingId == connection.BuildingId) == null)
            {
                var connectionToAdd = new BuildingAuctionConnection(connection.BuildingId, id);
                auction.Buildings.Add(connectionToAdd);
                building.Auctions.Add(connectionToAdd);
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
    [HttpDelete("buildings/{id}")]
    public IActionResult DeleteBuilding(int id, [FromBody] BuildingAuctionConnectionForAuctionDto connection)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        var building = _auctionsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == connection.BuildingId);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            var connectionToDelete = auction.Buildings.FirstOrDefault(building => building.BuildingId == connection.BuildingId);
            if (connectionToDelete != null)
            {
                auction.Buildings.Remove(connectionToDelete);
                building?.Auctions.Remove(connectionToDelete);
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
    [HttpGet("buyers/{id}")]
    public ActionResult<IEnumerable<BuyerAuctionConnectionForAuctionDto>> GetBuyers(int id)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get building offered on auction with id: {id}", id);
            return Ok(_mapper.Map<IEnumerable<BuyerAuctionConnectionForAuctionDto>>(auction.Buyers));
        }
    }

    /// <summary>
    /// Adds a new buyer to the list of buyers who participated in the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Buyer to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("buyers/{id}")]
    public IActionResult PostBuilding(int id, [FromBody] BuyerAuctionConnectionForAuctionDto connection)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        var buyer = _auctionsRepository.Buyers.FirstOrDefault(buyer => buyer.BuyerId == connection.BuyerId);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            if (buyer != null && auction.Buyers.FirstOrDefault(buyer => buyer.BuyerId == connection.BuyerId) == null)
            {
                var connectionToAdd = new BuyerAuctionConnection(connection.BuyerId, id);
                auction.Buyers.Add(connectionToAdd);
                buyer.Auctions.Add(connectionToAdd);
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
    [HttpDelete("buyers/{id}")]
    public IActionResult DeleteBuyer(int id, [FromBody] BuyerAuctionConnectionForAuctionDto connection)
    {
        var auction = _auctionsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == id);
        var buyer = _auctionsRepository.Buyers.FirstOrDefault(buyer => buyer.BuyerId == connection.BuyerId);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            var connectionToDelete = auction.Buyers.FirstOrDefault(buyer => buyer.BuyerId == connection.BuyerId);
            if (connectionToDelete != null)
            {
                auction.Buyers.Remove(connectionToDelete);
                buyer?.Auctions.Remove(connectionToDelete);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
