using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly IDbContextFactory<NonResidentialFundContext> _contextFactory;
    private readonly ILogger<BuildingController> _logger;
    private readonly IMapper _mapper;

    public BuildingController(IDbContextFactory<NonResidentialFundContext> contextFactory, ILogger<BuildingController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all buildings
    /// </summary>
    /// <returns>List of buildings</returns>
    [HttpGet]
    public async Task<IEnumerable<BuildingGetDto>> Get()
    {
        _logger.LogInformation("Get all buildings");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return _mapper.Map<IEnumerable<BuildingGetDto>>(ctx.Buildings);
    }

    /// <summary>
    /// Returns the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">registration number of the building</param>
    /// <returns>Result of operation and building object</returns>
    [HttpGet("{registrationNumber}")]
    public async Task<ActionResult<BuildingGetDto>> Get(int registrationNumber)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var building = ctx.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
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
    public async void Post([FromBody] BuildingPostDto building)
    {
        _logger.LogInformation("Created new building");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.Buildings.Add(_mapper.Map<Building>(building));
        ctx.SaveChanges();
    }

    /// <summary>
    /// Changes the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building to be changed</param>
    /// <param name="buildingToPut">New building data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{registrationNumber}")]
    public async Task<IActionResult> Put(int registrationNumber, [FromBody] BuildingPostDto buildingToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var building = ctx.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Updated building with registration number {registrationNumber}", registrationNumber);
            ctx.Buildings.Update(_mapper.Map(buildingToPut, building));
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Removes the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}")]
    public async Task<IActionResult> Delete(int registrationNumber)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var building = ctx.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Deleted building with registration number {registrationNumber}", registrationNumber);
            ctx.Buildings.Remove(building);
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Returning auctions, in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building</param>
    /// <returns>List of auctions, in which the building was put up for sale</returns>
    [HttpGet("{registrationNumber}/Auctions")]
    public async Task<ActionResult<IEnumerable<BuildingAuctionConnectionForBuildingDto>>> GetAuctions(int registrationNumber)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var building = ctx.Buildings.Include(building => building.Auctions).FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registrationNumber: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get auctions in which the building with registration number {registrationNumber} was put up for sale", registrationNumber);
            return Ok(_mapper.Map<IEnumerable<BuildingAuctionConnectionForBuildingDto>>(
                building.Auctions)
                );
        }
    }

    /// <summary>
    /// Adds a new auction to the list of auctions in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building</param>
    /// <param name="connection">Auction to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{registrationNumber}/Auctions")]
    public async Task<IActionResult> PostAuction(int registrationNumber, [FromBody] BuildingAuctionConnectionForBuildingDto connection)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var building = ctx.Buildings.Include(building => building.Auctions).FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            if (auction != null && building.Auctions.FirstOrDefault(conn => conn.AuctionId == connection.AuctionId) == null)
            {
                _logger.LogInformation("Added auction with id {connection.AuctionId} to the list of auctions in which the building with " +
                    "registration number {registrationNumber} was put up for sale", connection.AuctionId,  registrationNumber);
                var connectionToAdd = new BuildingAuctionConnection(registrationNumber, connection.AuctionId);
                building.Auctions.Add(connectionToAdd);
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
    /// Removes a auction from the list of auctions in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of building</param>
    /// <param name="connection">Auction to be remove</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}/Auctions")]
    public async Task<IActionResult> DeleteAuction(int registrationNumber, [FromBody] BuildingAuctionConnectionForBuildingDto connection)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var building = ctx.Buildings.Include(building => building.Auctions).FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        var auction = ctx.Auctions.FirstOrDefault(auction => auction.AuctionId == connection.AuctionId);
        if (building == null)
        {
            _logger.LogInformation("Not found buildiing with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Removed auction with id {connection.AuctionId} to the list of auctions in which the building with " +
                    "registration number {registrationNumber} was put up for sale", connection.AuctionId, registrationNumber);
            var connectionToDelete = building.Auctions.FirstOrDefault(conn => conn.AuctionId == connection.AuctionId);
            if (connectionToDelete != null)
            {
                building.Auctions.Remove(connectionToDelete);
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
