using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PonrfDomain;
using PonrfServer.Dto;
using System.Collections.Generic;

namespace PonrfServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrivatizedBuildingController : ControllerBase
{
    private readonly ILogger<PrivatizedBuildingController> _logger;

    private readonly PonrfRepository _ponrfRepository;

    private readonly IMapper _mapper;

    public PrivatizedBuildingController(ILogger<PrivatizedBuildingController> logger, PonrfRepository ponrfRepository, IMapper mapper)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<PrivatizedBuildingDto> Get()
    {
        _logger.LogInformation("Get all privatized buildings");
        return _mapper.Map<IEnumerable<PrivatizedBuildingDto>>(_ponrfRepository.PrivatizedBuildings);
    }

    [HttpGet("{id}")]
    public ActionResult<PrivatizedBuildingDto?> Get(int id)
    {
        var privatizedBuilding = _ponrfRepository.PrivatizedBuildings.FirstOrDefault(privatizedBuilding => privatizedBuilding.Id == id);
        if (privatizedBuilding == null)
        {
            _logger.LogInformation($"Not found privatized building with {id}");
            return NotFound();
        }
        else return Ok(_mapper.Map<PrivatizedBuildingDto>(privatizedBuilding));
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
