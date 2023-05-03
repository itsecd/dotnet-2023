using AutoMapper;
using BicycleRentals.Domain;
using BicycleRentals.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BicycleRentals.Server.ControllersModels;
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ILogger<RequestsController> _logger;

    private readonly IDbContextFactory<BicycleRentalContext> _contextFactory;

    private readonly IMapper _mapper;
    public RequestsController(ILogger<RequestsController> logger, IDbContextFactory<BicycleRentalContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary> 
    /// Return a list of all sports bicycles 
    /// </summary> 
    /// <returns>The list of all sports bicycles.</returns>
    [HttpGet("GetSportBicycles")]
    public async Task<ActionResult<IEnumerable<BicycleGetDto>>> GetSportBicycles()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var bicycles = await context.Bicycles
            .Where(b => b.TypeId == 3)
            .ToListAsync();
        if (bicycles == null)
            return NotFound();
        _logger.LogInformation("Get list of all sports bicycles ");
        return Ok(_mapper.Map<IEnumerable<BicycleGetDto>>(bicycles));
    }



    /// <summary> 
    /// Returns a list of all clients who rented mountain bicycles, sort by name.. 
    /// </summary> 
    /// <returns>The list of all clients who rented mountain bicycles, sort by name.</returns>
    [HttpGet("GetCustomersWhoRentedMountainBikes")]
    public async Task<ActionResult<IEnumerable<CustomerGetDto>>> GetCustomersWhoRentedMountainBikes()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var customers = await context.Customers
            .Include(c => c.Rentals)
            .ThenInclude(r => r.Bicycle)
            .Where(c => c.Rentals.Any(r => r.Bicycle.TypeId == 1))
            .OrderBy(c => c.FullName)
            .ToListAsync();
        if (customers == null)
            return NotFound();
        _logger.LogInformation("Get list of all clients who rented mountain bicycles, sort by name ");
        return Ok(_mapper.Map<IEnumerable<CustomerGetDto>>(customers));
    }

    /// <summary> 
    /// Returns a list of the total rental time for each type of bicycle. 
    /// </summary> 
    /// <returns>The list of the total rental time for each type of bicycle.</returns>
    [HttpGet("GetTotalRentalTimePerBicycleType")]
    public async Task<IActionResult> GetTotalRentalTimePerBicycleType()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();

        var rentalTimes = await context.Bicycles
                .Include(b => b.Rentals)
                .GroupBy(b => b.TypeId)
            .Select(g => new
            {
                Type_Name = g.Key,
                TotalRentalTime = g.Sum(b => b.Rentals.Sum(r => r.RentalTime))
            })
            .ToListAsync();
        if (rentalTimes == null)
            return NotFound();
        _logger.LogInformation("Get list of the total rental time for each type of bicycle ");
        return Ok(rentalTimes);
    }

    /// <summary> 
    /// Returns customer who have rented more bicycles. 
    /// </summary> 
    /// <returns>customer who have rented more bicycles.</returns>
    [HttpGet("GetCustomersWithMostRentals")]
    public async Task<IActionResult> GetCustomersWithMostRentals()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var customer = await context.Customers
            .Include(c => c.Rentals)
            .OrderByDescending(c => c.Rentals.Count)
            .FirstOrDefaultAsync();
        if (customer == null)
            return NotFound();

        var response = new { CustomerId = customer.FullName ?? "Unknown", RentalCount = customer.Rentals.Count };
        _logger.LogInformation("Get customer who have rented more bicycles ");
        return Ok(response);
    }

    /// <summary> 
    /// Returns a list of the top 5 most frequently rented bicycles. 
    /// </summary> 
    /// <returns>top 5 most frequently rented bicycles.</returns>

    [HttpGet("Top5MostRentedBikes")]
    public async Task<IActionResult> Top5MostRentedBikes()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var bikes = await context.Bicycles
            .Include(b => b.Rentals)
            .OrderByDescending(b => b.Rentals.Count())
            .Take(5)
            .Select(b => new { BicycleId = b.SerialNumber, RentalCount = b.Rentals.Count })
            .ToListAsync();
        if (bikes == null)
            return NotFound();
        _logger.LogInformation("Get top 5 most frequently rented bicycles ");
        return Ok(bikes);
    }
    
    /// <summary> 
    /// Returns a list of minimum, maximum and average bicycle rental time. 
    /// </summary> 
    /// <returns>minimum, maximum and average bicycle rental time.</returns>
    [HttpGet("MinMaxAvgRentalTime")]
    public async Task<IActionResult> MinMaxAvgRentalTime()
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var result = await context.Bicycles
                .Include(b => b.Rentals)
                .GroupBy(b => b.TypeId)
            .Select(g => new
            {
                Type_Name = g.Key,
                MinRentalTime = g.Min(b => b.Rentals.Min(r => r.RentalTime)),
                MaxRentalTime = g.Max(b => b.Rentals.Max(r => r.RentalTime)),
                AvgRentalTime = g.Average(b => b.Rentals.Average(r => r.RentalTime)),
            })
            .ToListAsync();
        if (result == null)
            return NotFound();
        _logger.LogInformation("Get list of minimum, maximum and average bicycle rental time ");
        return Ok(result);
    }
}
