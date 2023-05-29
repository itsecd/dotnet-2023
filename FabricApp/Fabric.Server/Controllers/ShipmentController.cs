using AutoMapper;
using Fabrics.Domain;
using Fabrics.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fabrics.Server.Controllers;
/// <summary>
/// Shipment controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ShipmentController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ShipmentController> _logger;
    /// <summary>
    /// Used to store DbContext
    /// </summary>
    private readonly IDbContextFactory<FabricsDbContext> _contextFactory;
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// ShipmentController constructor
    /// </summary>
    public ShipmentController(ILogger<ShipmentController> logger, IDbContextFactory<FabricsDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get list of all shipments.
    /// </summary>
    /// <returns>List of shipments</returns>
    [HttpGet]
    public async Task<IEnumerable<ShipmentGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get shipment");
        var shipments = await context.Shipments.ToListAsync();
        return _mapper.Map<IEnumerable<ShipmentGetDto>>(shipments);
    }
    /// <summary>
    /// Get shipment by id
    /// </summary>
    /// <param name="id">Id of shipment to get</param>
    /// <returns>Shipment</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ShipmentGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var shipment = await context.Shipments.FirstOrDefaultAsync(shipment => shipment.Id == id);
        if (shipment == null)
        {
            _logger.LogInformation("Not found shipment:{id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ShipmentGetDto>(shipment));
        }
    }
    /// <summary>
    /// Post new shipment
    /// </summary>
    /// <param name="shipment">Shipment to post</param>
    /// <returns>ShipmentGetDto</returns>
    [HttpPost]
    public async Task<ActionResult<ShipmentGetDto>> Post([FromBody] ShipmentPostDto shipment)
    {
        var mappedShipment = _mapper.Map<Shipment>(shipment);

        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Shipments.AddAsync(mappedShipment);
        await context.SaveChangesAsync();

        return Ok(_mapper.Map<ShipmentGetDto>(mappedShipment));
    }
    /// <summary>
    /// Put shipment
    /// </summary>
    /// <param name="id">Id of shipment to put</param>
    /// <param name="shipmentToPut">Shipment to put</param>
    /// <returns>Result</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ShipmentPostDto shipmentToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var shipment = await context.Shipments.FirstOrDefaultAsync(shipment => shipment.Id == id);
        if (shipment == null)
        {
            _logger.LogInformation("Not found shipment:{id}", id);
            return NotFound();
        }
        else
        {
            context.Update(_mapper.Map(shipmentToPut, shipment));
            await context.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete shipment
    /// </summary>
    /// <param name="id">Id of shipment to delete</param>
    /// <returns>Result</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var shipment = await context.Shipments.FirstOrDefaultAsync(shipment => shipment.Id == id);
        if (shipment == null)
        {
            _logger.LogInformation("Not found shipment:{id}", id);
            return NotFound();
        }
        else
        {
            context.Shipments.Remove(shipment);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
