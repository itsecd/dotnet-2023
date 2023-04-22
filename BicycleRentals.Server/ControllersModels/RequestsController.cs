using AutoMapper;
using BicycleRentals.Domain;
using BicycleRentals.Server.Dto;
using BicycleRentals.Server.Respostory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

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
    public async Task<IEnumerable<BicycleGetDto>> GetSportBicycles()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await (from bicycle in context.Bicycles
                      where bicycle.TypeId == 3
                      select _mapper.Map<Bicycle, BicycleGetDto>(bicycle)).ToListAsync();
    }

    /// <summary> 
    /// Returns a list of all clients who rented mountain bicycles, sort by name.. 
    /// </summary> 
    /// <returns>The list of all clients who rented mountain bicycles, sort by name.</returns>
    [HttpGet("GetCustomersWhoRentedMountainBikes")]
    public async Task<IEnumerable<CustomerGetDto>> GetCustomersWhoRentedMountainBikes()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await (from customer in context.Customers.Include(c => c.Rentals)
                                   .ThenInclude(r => r.Bicycle)
                                   .Where(c => c.Rentals.Any(r => r.Bicycle.TypeId == 1))
                                   .OrderByDescending(c => c.FullName)
                                   select _mapper.Map<Customer, CustomerGetDto>(customer))
                                   .ToListAsync();               
    }

    /// <summary> 
    /// Returns a list of the total rental time for each type of bicycle. 
    /// </summary> 
    /// <returns>The list of the total rental time for each type of bicycle.</returns>
    [HttpGet("GetTotalRentalTimePerBicycleType")]
    public async Task<IEnumerable> GetTotalRentalTimePerBicycleType()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();       
        return await (from rental in context.BicycleRentals.Include(r => r.Bicycle.TypeId)
                      group rental by rental.Bicycle.TypeId into g
                      select new{TypeId = g.Key,TotalTime = g.Sum(br => br.RentalDurationHours)}
                      ).ToListAsync();
    }

    /// <summary> 
    /// Returns customer who have rented more bicycles. 
    /// </summary> 
    /// <returns>customer who have rented more bicycles.</returns>
    [HttpGet("GetCustomersWithMostRentalsReturnsCorrectCount")]
    public async Task<IEnumerable> GetCustomersWithMostRentals()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await ( from customer in context.Customers.Include(c => c.Rentals)
                                        .OrderByDescending(c=> c.Rentals.Count())
                                        .Take(1)                                         
                                         select new{CustomerId = customer.FullName,RentalCount = customer.Rentals.Count()}
                                         ).ToListAsync();        
    }

    /// <summary> 
    /// Returns a list of the top 5 most frequently rented bicycles. 
    /// </summary> 
    /// <returns>top 5 most frequently rented bicycles.</returns>
    [HttpGet("Top5MostRentedBikes")]
    public async Task<IEnumerable> Top5MostRentedBikes()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await (from bicycle in context.Bicycles.Include(b => b.Rentals)
           .OrderByDescending(b => b.Rentals.Count())
           .Take(5)
            select new { BicycleId = bicycle.SerialNumber, RentalCount = bicycle.Rentals.Count()}
            ).ToListAsync();
    }

    /// <summary> 
    /// Returns a list of minimum, maximum and average bicycle rental time. 
    /// </summary> 
    /// <returns>minimum, maximum and average bicycle rental time.</returns>
    [HttpGet("MinMaxAvgRentalTime")]
    public async Task<IEnumerable> MinMaxAvgRentalTime()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await (from rental in context.BicycleRentals.Include(r => r.Bicycle)     
                      group rental by rental.Bicycle.TypeId into g
                      select new
                           {
                               TypeId = g.Key,
                               minRentalTime = g.Min(br => br.RentalDurationHours),
                               maxRentalTime = g.Max(br => br.RentalDurationHours),
                               avgRentalTime = g.Average(br => br.RentalDurationHours)
                           }).ToListAsync();
    }
}
