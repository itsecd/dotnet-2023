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
    [HttpGet("{id}")]
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
}
