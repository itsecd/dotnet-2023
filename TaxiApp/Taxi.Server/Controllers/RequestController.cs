using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for request
/// </summary>
public class RequestController : ControllerBase
{
    private readonly IDbContextFactory<TaxiDbContext> _contextFactory;
    private readonly ILogger<RequestController> _logger;
    private readonly IMapper _mapper;

    public RequestController(IDbContextFactory<TaxiDbContext> contextFactory, IMapper mapper,
        ILogger<RequestController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    ///     Get method which output all information about the individual driver and his vehicle
    /// </summary>
    /// <param name="id"> Identifier of driver</param>
    /// <returns>
    ///     Return list of drivers
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("vehicles_and_drivers/{id}")]
    public async Task<ActionResult<IEnumerable<VehicleAndDriverGetDto>>> GetVehicleAndDriver(ulong id)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        var query = await (from vehicle in ctx.Vehicles
            where vehicle.Driver.Id == id
            select new
            {
                vehicle.RegistrationCarPlate,
                vehicle.Colour,
                vehicle.Driver.FirstName,
                vehicle.Driver.LastName,
                vehicle.Driver.Patronymic,
                vehicle.Driver.PhoneNumber,
                vehicle.Driver.Passport,
                vehicle.VehicleClassification.Brand,
                vehicle.VehicleClassification.Model,
                vehicle.VehicleClassification.Class
            }).ToListAsync();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found driver and vehicle by driver id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get driver and vehicle by driver id={id}", id);
        return Ok(query);
    }

    /// <summary>
    ///     Get method which output all passengers who have ride in the given period, sorted by full name
    /// </summary>
    /// <param name="minDate"> Start date</param>
    /// <param name="maxDate"> End date</param>
    /// <returns>
    ///     Return list of passengers
    /// </returns>
    [HttpGet("passengers_over_given_period")]
    public async Task<ActionResult<IEnumerable<PassengerGetDto>>> GetPassengerOverGivenPeriod(DateTime minDate,
        DateTime maxDate)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        var query = await (from ride in ctx.Rides
                where ride.RideDate <= maxDate && ride.RideDate >= minDate
                select new
                {
                    ride.Passenger.LastName,
                    ride.Passenger.FirstName,
                    ride.Passenger.Patronymic
                }).Distinct().OrderBy(fullname => fullname.LastName)
            .ThenBy(fullname => fullname.FirstName)
            .ThenBy(fullname => fullname.Patronymic).ToListAsync();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found passengers over given period");
            return NotFound();
        }

        _logger.LogInformation("Get passengers over given period");
        return Ok(query);
    }

    /// <summary>
    ///     Get method which output the number of ride for each passenger
    /// </summary>
    /// <returns>
    ///     Return list of passenger and rides count
    ///     Signalization of success or error
    /// </returns>
    [HttpGet("count_passenger_rides")]
    public async Task<ActionResult<IEnumerable<CountPassengerRidesGetDto>>> GetCountPassengerRides()
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        var query = await (from passenger in ctx.Passengers
            select new
            {
                passenger.LastName,
                passenger.FirstName,
                passenger.Patronymic,
                passenger.Rides.Count
            }).ToListAsync();

        if (query.Count == 0)
        {
            _logger.LogInformation("Not found passengers");
            return NotFound();
        }

        _logger.LogInformation("Get count passenger rides");
        return Ok(query);
    }

    /// <summary>
    ///     Get method which output the top 2 drivers by the number of ride made
    /// </summary>
    /// <returns>
    ///     Return list of drivers
    /// </returns>
    [HttpGet("count_top_driver_rides")]
    public async Task<IEnumerable<Driver>> GetTopDriver()
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        List<Driver> query = await (from vehicle in ctx.Vehicles
            from driver in ctx.Drivers
            where vehicle.DriverId == driver.Id
            orderby vehicle.Rides.Count
            select driver).Distinct().Take(2).ToListAsync();

        _logger.LogInformation("Get top 2 driver by count of rides");
        return query;
    }

    /// <summary>
    ///     Get method which output information about the number of rides, average time and maximum ride time for each driver
    /// </summary>
    /// <returns>
    ///     Return list of driver, rides count, average time, maximum time
    /// </returns>
    [HttpGet("infos_about_rides")]
    public async Task<ActionResult<IEnumerable<InfosAboutRidesGetDto>>> GetInfosAboutRides()
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        var query = await (from ridesInfo in from ride in ctx.Rides
                group ride by ride.VehicleId
                into grp
                select new
                {
                    vehicleId = grp.Key,
                    count = grp.Count(),
                    max = grp.Max(ride => ride.RideTime),
                    rideTimesInSeconds = grp.Select(ride => ride.RideTime.TotalSeconds)
                }
            from vehicle in ctx.Vehicles
            where ridesInfo.vehicleId == vehicle.Id
            select new
            {
                vehicle.Driver.LastName,
                vehicle.Driver.FirstName,
                vehicle.Driver.Patronymic,
                ridesInfo.count,
                avg = TimeSpan.FromSeconds(ridesInfo.rideTimesInSeconds.Sum() / ridesInfo.count),
                ridesInfo.max
            }).ToListAsync();

        _logger.LogInformation("Get infos about passengers rides");
        return Ok(query);
    }

    /// <summary>
    ///     Get method which output the information about the passengers who have made the maximum number of rides in a given
    ///     period
    /// </summary>
    /// <param name="minDate"> Start date</param>
    /// <param name="maxDate"> End date</param>
    /// <returns>
    ///     Return list of passengers
    /// </returns>
    [HttpGet("max_rides_of_passenger")]
    public async Task<ActionResult<IEnumerable<CountPassengerRidesGetDto>>> GetMaxRidesOfPassenger(DateTime minDate,
        DateTime maxDate)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        var subquery = await (from passenger in ctx.Passengers
            from ride in passenger.Rides
            where ride.RideDate < maxDate && ride.RideDate > minDate
            group passenger.Id by passenger
            into grp
            select new
            {
                grp.Key.LastName,
                grp.Key.FirstName,
                grp.Key.Patronymic,
                count = grp.Count()
            }).ToListAsync();

        if (subquery.Count == 0)
        {
            _logger.LogInformation("Not found passengers");
            return NotFound();
        }

        var max = subquery.Max(elem => elem.count);

        var query = (from sq in subquery
            where sq.count == max
            select new
            {
                sq.LastName,
                sq.FirstName,
                sq.Patronymic,
                max
            }).ToList();

        _logger.LogInformation("Get passenger with max count of rides");
        return Ok(query);
    }
}