using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BuyerController : ControllerBase
{
    private readonly ILogger<BuyerController> _logger;

    private readonly INonResidentialFundRepository _buyersRepository;

    private readonly IMapper _mapper;

    public BuyerController(ILogger<BuyerController> logger, INonResidentialFundRepository buyersRepository, IMapper mapper)
    {
        _logger = logger;
        _buyersRepository = buyersRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all buyers
    /// </summary>
    /// <returns>List of buyers</returns>
    [HttpGet]
    public IEnumerable<Buyer> Get()
    {
        _logger.LogInformation("Get all buyers");
        return _buyersRepository.Buyers;
    }

    /// <summary>
    /// Returns the buyer by the specified id
    /// </summary>
    /// <param name="id">id of the buyer</param>
    /// <returns>Result of operation and building object</returns>
    [HttpGet("{id}")]
    public ActionResult<Building> Get(int id)
    {
        var buyer = _buyersRepository.Buyers.FirstOrDefault(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return Ok(buyer);
        }
    }

    /// <summary>
    /// Creates new buyer
    /// </summary>
    /// <param name="buyer">Buyer to be created</param>
    [HttpPost]
    public void Post([FromBody] BuyerPostDto buyer)
    {
        _buyersRepository.Buyers.Add(_mapper.Map<Buyer>(buyer));
    }

    /// <summary>
    /// Changes the buyer by the specified id
    /// </summary>
    /// <param name="id">Id of the buyer to be changed</param>
    /// <param name="buyerToPut">New buyer data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BuyerPostDto buyerToPut)
    {
        var buyer = _buyersRepository.Buyers.FirstOrDefault(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(buyerToPut, buyer);
            return Ok();
        }
    }

    /// <summary>
    /// Removes the buyer by the specified id
    /// </summary>
    /// <param name="id">Id of the buyer to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var buyer = _buyersRepository.Buyers.FirstOrDefault(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _buyersRepository.Buyers.Remove(buyer);
            return Ok();
        }
    }

    /// <summary>
    /// Returns auctions in which the specified buyer participated
    /// </summary>
    /// <param name="Id">Id of the buyer</param>
    /// <returns>List of auctions, in which the specified buyer participated</returns>
    [HttpGet("auctions/{Id}")]
    public ActionResult<IEnumerable<BuyerAuctionConnectionForBuyerDto>> GetAuctions(int Id)
    {
        var buyer = _buyersRepository.Buyers.FirstOrDefault(buyer => buyer.BuyerId == Id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {Id}", Id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get auctions in which the buyer with id {Id} participated", Id);
            return Ok(_mapper.Map<IEnumerable<BuyerAuctionConnectionForBuyerDto>>(buyer.Auctions));
        }
    }

    /// <summary>
    /// Adds a new auction to the list of auctions in which the specified buyer participated
    /// </summary>
    /// <param name="id">Id of the buyer</param>
    /// <param name="connection">Auction to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("auctions/{id}")]
    public IActionResult PostAuction(int id, [FromBody] BuyerAuctionConnectionForBuyerDto connection)
    {
        var buyer = _buyersRepository.Buyers.FirstOrDefault(buyer => buyer.BuyerId == id);
        var auction = _buyersRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            if (auction != null && buyer.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId) == null)
            {
                BuyerAuctionConnection connectionToAdd = new BuyerAuctionConnection(id, connection.AuctionId);
                buyer.Auctions.Add(connectionToAdd);
                auction.Buyers.Add(connectionToAdd);
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
    /// <param name="Id">Id of the buyer</param>
    /// <param name="connection">Auction to be remove</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("auctions/{Id}")]
    public IActionResult DeleteAuction(int Id, [FromBody] BuyerAuctionConnectionForBuyerDto connection)
    {
        var buyer = _buyersRepository.Buyers.FirstOrDefault(buyer => buyer.BuyerId == Id);
        var auction = _buyersRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {Id}", Id);
            return NotFound();
        }
        else
        {
            var connectionToDelete = buyer.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
            if (connectionToDelete != null)
            {
                buyer.Auctions.Remove(connectionToDelete);
                auction?.Buyers.Remove(connectionToDelete);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
