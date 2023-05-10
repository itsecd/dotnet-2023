using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Server.Dto;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for request
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly RentalServiceDbContext _context;
    private readonly ILogger<ClientController> _logger;
    private readonly IMapper _mapper;

    public RequestController(RentalServiceDbContext context, IMapper mapper, ILogger<ClientController> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    ///     Get information about vehicles
    /// </summary>
    /// <returns>
    ///     Return list of vehicles
    /// </returns>
    [HttpGet("vehicles")]
    public async Task<ActionResult<IEnumerable<VehicleGetDto>>> GetVehicles()
    {
        var query = await (from vehicle in _context.Vehicles
            select new
            {
                vehicle.Id,
                vehicle.Colour,
                vehicle.VehicleModel.Model,
                vehicle.VehicleModel.Brand,
                vehicle.Number
            }).ToListAsync();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found vehicles");
            return NotFound();
        }

        return Ok(query);
    }

    /// <summary>
    ///     Get information about clients who took the car with the specified identifier
    /// </summary>
    /// <returns>
    ///     List of clients
    /// </returns>
    [HttpGet("clients_by_model_id/{id}")]
    public async Task<IActionResult> GetClientsByModelId(ulong id)
    {
        List<ClientGetDto> query = await (from client in _context.Clients
            join issuedCar in _context.IssuedCars on client.Id equals issuedCar.ClientId
            join vehicle in _context.Vehicles on issuedCar.VehicleId equals vehicle.Id
            where vehicle.VehicleModel.Id == id
            orderby client.LastName, client.FirstName, client.Patronymic
            select _mapper.Map<ClientGetDto>(client)).ToListAsync();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found clients with this id");
            return NotFound();
        }

        return Ok(query);
    }

    /// <summary>
    ///     Get information about cars that are rented
    /// </summary>
    /// <returns>
    ///     List of vehicles
    /// </returns>
    [HttpGet("cars_for_rent")]
    public async Task<IActionResult> GetCarsForRent()
    {
        var query = await (from issuedCar in _context.IssuedCars
            join vehicle in _context.Vehicles on issuedCar.VehicleId equals vehicle.Id
            where issuedCar.RefundInformationId == null
            select new
            {
                vehicle.Id,
                vehicle.Colour,
                vehicle.VehicleModel.Model,
                vehicle.VehicleModel.Brand,
                vehicle.Number
            }).ToListAsync();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found cars for rent");
            return NotFound();
        }

        return Ok(query);
    }


    /// <summary>
    ///     Get information about the top 5 most frequently rented cars
    /// </summary>
    /// <returns>
    ///     List of vehicles
    /// </returns>
    [HttpGet("top_five_frequently_rented_vehicles")]
    public async Task<IActionResult> GetTopFiveFrequentlyRentedVehicles()
    {
        var query = await (from issuedCar in _context.IssuedCars
            join vehicle in _context.Vehicles on issuedCar.VehicleId equals vehicle.Id
            orderby vehicle.RentalCases.Count
            select new
            {
                vehicle.Id,
                vehicle.Number,
                vehicle.VehicleModel.Model,
                vehicle.VehicleModel.Brand,
                vehicle.Colour,
                vehicle.RentalCases.Count
            }).Take(5).Reverse().ToListAsync();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found records");
            return NotFound();
        }

        _logger.LogInformation("Get top five frequently rented vehicles");
        return Ok(query);
    }


    /// <summary>
    ///     Get the number of leases for each car
    /// </summary>
    /// <returns>
    ///     List of vehicles and rentals count
    /// </returns>
    [HttpGet("number_of_leases_for_each_car")]
    public async Task<IActionResult> GetNumberOfCarRentals()
    {
        var query = await (from vehicle in _context.Vehicles
            select new
            {
                vehicle.Id,
                vehicle.Number,
                vehicle.VehicleModel.Model,
                vehicle.VehicleModel.Brand,
                vehicle.Colour,
                vehicle.RentalCases.Count
            }).ToListAsync();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found records");
            return NotFound();
        }

        _logger.LogInformation("Get number of car rentals");
        return Ok(query);
    }


    /// <summary>
    ///     Get information about rental locations where cars have been rented the maximum number of times,
    ///     arrange by name
    /// </summary>
    /// <returns>
    ///     List of rental points
    /// </returns>
    [HttpGet("top_car_rental_locations")]
    public async Task<IActionResult> GetTopCarRentalLocations()
    {
        var subquery = await (from issuedCar in _context.IssuedCars
            join rentalInformation in _context.RentalInformations on issuedCar.RentalInformationId equals
                rentalInformation.Id
            join rentalPoint in _context.RentalPoints on rentalInformation.RentalPointId equals rentalPoint.Id
            group rentalPoint.Id by rentalPoint
            into grp
            select new
            {
                grp.Key.Title,
                grp.Key.Address,
                countOfLeases = grp.Count()
            }).ToListAsync();

        if (subquery.Count == 0)
        {
            _logger.LogInformation("Not found rental points");
            return NotFound();
        }

        var maxNumberOfRents = subquery.Max(elem => elem.countOfLeases);

        var query = (from sq in subquery
            where sq.countOfLeases == maxNumberOfRents
            select sq).ToList();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found records");
            return NotFound();
        }

        _logger.LogInformation("Get rental points");
        return Ok(query);
    }
}