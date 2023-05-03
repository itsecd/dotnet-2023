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
public class ShipmentsController : ControllerBase
{
    private readonly ILogger _logger;

    private readonly FabricsDbContext _context;

    private readonly IMapper _mapper;

    public ShipmentsController(FabricsDbContext context, IMapper mapper, ILogger logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShipmentGetDto>>> GetShipments()
    {
        _logger.LogInformation("Get shipments");
        if (_context.Shipments == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<ShipmentGetDto>(_context.Shipments).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShipmentGetDto>> GetShipment(int id)
    {
        if (_context.Shipments == null)
        {
            return NotFound();
        }
        var shipment = await _context.Shipments.FindAsync(id);

        if (shipment == null)
        {
            return NotFound();
        }

        return _mapper.Map<ShipmentGetDto>(shipment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutShipment(int id, ShipmentPostDto shipment)
    {

        if (_context.Fabrics == null)
        {
            return NotFound();
        }
        var shipmentToModify = await _context.Shipments.FindAsync(id);
        if (shipmentToModify == null)
        {
            return NotFound();
        }
        _mapper.Map(shipment, shipmentToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ShipmentGetDto>> PostShipment(ShipmentPostDto shipment)
    {
        if (_context.Shipments == null)
        {
            return Problem("Entity set 'FabricsDbContext.Shipments'  is null.");
        }

        var mappedShipment = _mapper.Map<Shipment>(shipment);

        _context.Shipments.Add(mappedShipment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostShipment", new { id = mappedShipment.Id }, _mapper.Map<FabricGetDto>(mappedShipment));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShipment(int id)
    {
        if (_context.Shipments == null)
        {
            return NotFound();
        }
        var shipment = await _context.Shipments.FindAsync(id);
        if (shipment == null)
        {
            return NotFound();
        }

        _context.Shipments.Remove(shipment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
