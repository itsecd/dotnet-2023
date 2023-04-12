using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PonrfDomain;
using PonrfServer.Dto;
using PonrfServer.Repository;

namespace PonrfServer.Controllers;

/// <summary>
/// Auction controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly ILogger<AuctionController> _logger;

    private readonly IPonrfRepository _ponrfRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for AuctionController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="ponrfRepository"></param>
    /// <param name="mapper"></param>
    public AuctionController(ILogger<AuctionController> logger, IPonrfRepository ponrfRepository, IMapper mapper)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about all auctions
    /// </summary>
    /// <returns>List of auctions</returns>
    [HttpGet]
    public IEnumerable<AuctionGetDto> Get()
    {
        _logger.LogInformation("Get information about all auctions");
        return _mapper.Map<IEnumerable<AuctionGetDto>>(_ponrfRepository.Auctions);
    }

    /// <summary>
    /// Get an auction by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Auction</returns>
    [HttpGet("{id}")]
    public ActionResult<AuctionGetDto?> Get(int id)
    {
        var auction = _ponrfRepository.Auctions.FirstOrDefault(auction => auction.Id == id);
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
        _logger.LogInformation("Post a new auction");
        _ponrfRepository.Auctions.Add(_mapper.Map<Auction>(auction));
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
        var auction = _ponrfRepository.Auctions.FirstOrDefault(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(auctionToPut, auction);
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
        var auction = _ponrfRepository.Auctions.FirstOrDefault(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete an auction");
            _ponrfRepository.Auctions.Remove(auction);
            return Ok();
        }
    }
}
