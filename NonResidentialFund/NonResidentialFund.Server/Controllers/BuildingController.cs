using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;

    private readonly INonResidentialFundRepository _buildingsRepository;

    private readonly IMapper _mapper;

    public BuildingController(ILogger<BuildingController> logger, INonResidentialFundRepository buildingsRepository, IMapper mapper)
    {
        _logger = logger;
        _buildingsRepository = buildingsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all buildings
    /// </summary>
    /// <returns>List of buildings</returns>
    [HttpGet]
    public IEnumerable<BuildingGetDto> Get()
    {
        _logger.LogInformation("Get all buildings");
        return _mapper.Map<IEnumerable<BuildingGetDto>>(_buildingsRepository.Buildings);
    }

    /// <summary>
    /// Returns the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">registration number of the building</param>
    /// <returns>Result of operation and building object</returns>
    [HttpGet("{registrationNumber}")]
    public ActionResult<BuildingGetDto> Get(int registrationNumber)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get building with registration number: {registrationNumber}", registrationNumber);
            return Ok(_mapper.Map<BuildingGetDto>(building));
        }
    }

    /// <summary>
    /// Creates new building
    /// </summary>
    /// <param name="building">Building to be created</param>
    [HttpPost]
    public void Post([FromBody] BuildingPostDto building)
    {
        _buildingsRepository.Buildings.Add(_mapper.Map<Building>(building));
    }

    /// <summary>
    /// Changes the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building to be changed</param>
    /// <param name="buildingToPut">New building data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{registrationNumber}")]
    public IActionResult Put(int registrationNumber, [FromBody] BuildingPostDto buildingToPut)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _mapper.Map(buildingToPut, building);
            return Ok();
        }
    }

    /// <summary>
    /// Removes the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}")]
    public IActionResult Delete(int registrationNumber)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _buildingsRepository.Buildings.Remove(building);
            return Ok();
        }
    }

    /// <summary>
    /// Returning auctions, in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building</param>
    /// <returns>List of auctions, in which the building was put up for sale</returns>
    [HttpGet("{registrationNumber}/Auctions")]
    public ActionResult<IEnumerable<BuildingAuctionConnectionForBuildingDto>> GetAuctions(int registrationNumber)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registrationNumber: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get auctions in which the building with registration number {registrationNumber} was put up for sale", registrationNumber);
            return Ok(_mapper.Map<IEnumerable<BuildingAuctionConnectionForBuildingDto>>(building.Auctions));
        }
    }

    /// <summary>
    /// Adds a new auction to the list of auctions in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building</param>
    /// <param name="connection">Auction to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{registrationNumber}/Auctions")]
    public IActionResult PostAuction(int registrationNumber, [FromBody] BuildingAuctionConnectionForBuildingDto connection)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        var auction = _buildingsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            if (auction != null && building.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId) == null)
            {
                var connectionToAdd = new BuildingAuctionConnection(registrationNumber, connection.AuctionId);
                building.Auctions.Add(connectionToAdd);
                auction.Buildings.Add(connectionToAdd);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }

    /// <summary>
    /// Removes a auction from the list of auctions in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of building</param>
    /// <param name="connection">Auction to be remove</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}/Auctions")]
    public IActionResult DeleteAuction(int registrationNumber, [FromBody] BuildingAuctionConnectionForBuildingDto connection)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        var auction = _buildingsRepository.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
        if (building == null)
        {
            _logger.LogInformation("Not found buildiing with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            var connectionToDelete = building.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
            if (connectionToDelete != null)
            {
                building.Auctions.Remove(connectionToDelete);
                auction?.Buildings.Remove(connectionToDelete);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
