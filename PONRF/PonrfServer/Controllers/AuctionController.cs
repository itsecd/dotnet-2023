using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PonrfDomain;
using PonrfServer.Dto;
using System.Collections.Generic;

namespace PonrfServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly ILogger<AuctionController> _logger;

    private readonly PonrfRepository _ponrfRepository;

    private readonly IMapper _mapper;

    public AuctionController(ILogger<AuctionController> logger, PonrfRepository ponrfRepository, IMapper mapper)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<AuctionDto> Get()
    {
        _logger.LogInformation("Get all auctions");
        return _mapper.Map<IEnumerable<AuctionDto>>(_ponrfRepository.Auctions);
    }

    [HttpGet("{id}")]
    public ActionResult<AuctionDto?> Get(int id)
    {
        var auction = _ponrfRepository.Auctions.FirstOrDefault(auction => auction.Id == id);
        if (auction == null)
        {
            _logger.LogInformation($"Not found auction with {id}");
            return NotFound();
        }
        else return Ok(_mapper.Map<AuctionDto>(auction));
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
