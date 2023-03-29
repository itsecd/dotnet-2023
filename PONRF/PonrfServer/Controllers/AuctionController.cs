using Microsoft.AspNetCore.Mvc;
using PonrfDomain;

namespace PonrfServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly ILogger<AuctionController> _logger;

    private readonly PonrfRepository _ponrfRepository;

    public AuctionController(ILogger<AuctionController> logger, PonrfRepository ponrfRepository)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
    }


    [HttpGet]
    public IEnumerable<Auction> Get()
    {
        _logger.LogInformation("Get all auctions");
        return _ponrfRepository.Auctions;
    }

    [HttpGet("{id}")]
    public ActionResult<Auction?> Get(int id)
    {
        var auction = _ponrfRepository.Auctions.FirstOrDefault(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation($"Not found auction with {id}");
            return NotFound();
        }
        else return Ok(auction);
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
