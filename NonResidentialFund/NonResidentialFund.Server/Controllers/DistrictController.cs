using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DistrictController : ControllerBase
{
    private readonly IDbContextFactory<NonResidentialFundContext> _contextFactory;
    private readonly ILogger<DistrictController> _logger;
    private readonly INonResidentialFundRepository _districtsRepository;
    private readonly IMapper _mapper;

    public DistrictController(IDbContextFactory<NonResidentialFundContext> contextFactory, ILogger<DistrictController> logger, 
        INonResidentialFundRepository districtsRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _districtsRepository = districtsRepository;
        _mapper = mapper;

        using var ctx = _contextFactory.CreateDbContext();
        Console.WriteLine(ctx.Districts.Count());
    }

    /// <summary>
    /// Returns all districts
    /// </summary>
    /// <returns>List of districts</returns>
    [HttpGet]
    public IEnumerable<DistrictGetDto> Get()
    {
        _logger.LogInformation("Get all districts");
        return _mapper.Map<IEnumerable<DistrictGetDto>>(_districtsRepository.Districts);
    }

    /// <summary>
    /// Returns the district by the specified id
    /// </summary>
    /// <param name="id">id of the district</param>
    /// <returns>Result of operation and district object</returns>
    [HttpGet("{id}")]
    public ActionResult<DistrictGetDto> Get(int id)
    {
        var district = _districtsRepository.Districts.FirstOrDefault(district => district.DistrictId == id);
        if (district == null)
        {
            _logger.LogInformation("Not found district with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get district with id: {id}", id);
            return Ok(_mapper.Map<DistrictGetDto>(district));
        }
    }

    /// <summary>
    /// Creates new district
    /// </summary>
    /// <param name="district">District to be created</param>
    [HttpPost]
    public void Post([FromBody] DistrictPostDto district)
    {
        _districtsRepository.Districts.Add(_mapper.Map<District>(district));
    }

    /// <summary>
    /// Changes the district by the specified id
    /// </summary>
    /// <param name="id">Id of the district to be changed</param>
    /// <param name="districtToPut">New district data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DistrictPostDto districtToPut)
    {
        var district = _districtsRepository.Districts.FirstOrDefault(district => district.DistrictId == id);
        if (district == null)
        {
            _logger.LogInformation("Not found district {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(districtToPut, district);
            return Ok();
        }
    }

    /// <summary>
    /// Removes the district by the specified id
    /// </summary>
    /// <param name="id">Id of the district to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var district = _districtsRepository.Districts.FirstOrDefault(district => district.DistrictId == id);
        if (district == null)
        {
            _logger.LogInformation("Not found district with id: {id}", id);
            return NotFound();
        }
        else
        {
            _districtsRepository.Districts.Remove(district);
            return Ok();
        }
    }
}
